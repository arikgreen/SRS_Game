using SRS_Game.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Interfaces;
using SRS_Game.Models;
using SRS_Game.Helpers;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Xaml;
using SRS_Game.Models.Srs;

namespace SRS_Game.Services
{
    public class DocumentService : IReadableDocument, IWritableDocument
    {
        private readonly SRS_GameDbContext _context;

        public DocumentService(SRS_GameDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Document> GetAll()
        {
            return [.. _context.Documents];
        }
        
        public async Task<DocumentViewModel?> GetAsync(int id)
        {
            var document = await (from d in _context.Documents
                                    where d.Id == id
                                  join a in _context.Participants
                                    on d.AuthorId equals a.Id 
                                  join o in _context.Participants
                                    on d.TeamLeaderId equals o.Id
                                  join t in _context.Teams 
                                    on d.TeamId equals t.Id into teamGroup          // left join
                                  from team in teamGroup.DefaultIfEmpty()           // Team can be null
                                  join p in _context.Projects 
                                    on d.ProjectId equals p.Id into projectGroup
                                  from project in projectGroup.DefaultIfEmpty()     // Project can be null
                                  select new DocumentViewModel
                                  {
                                      Id = d.Id,
                                      Name = d.Name,
                                      Destination = d.Destination,
                                      AuthorId = d.AuthorId,
                                      Author = a.FirstName + " " + a.LastName,
                                      TeamId = d.TeamId,
                                      Team = team.Name,
                                      TeamLeaderId = d.TeamLeaderId,
                                      Owner = o.FirstName + " " + o.LastName,
                                      ProjectId = d.ProjectId,
                                      Project = project.Name,
                                      CreatedDate = d.CreatedDate,
                                      UpdatedDate = d.UpdatedDate,
                                      Version = d.Version
                                  }
                            ).FirstOrDefaultAsync();

            return document;
        }

        public async Task<SelectList> GetDocumentsForSelectListAsync()
        {
            var documents = await _context.Documents
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();

            //documents.Insert(0, new SelectListItem { Value = "", Text = "-- Select an option --" });

            return new SelectList(documents, "Value", "Text");
        }

        public bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }

        public Task AddAsync(Document document)
        {
            /* Code to add document */
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Document document)
        {
            /* Code to update document */
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            /* Code to delete document */
            throw new NotImplementedException();
        }

        public async Task<string> GetTranscriptSourceContent(int id)
        { 
            var fileContent = await _context.Attachements
                .Where(d => d.DocumentId == id)
                .Where(o => o.FileName.Contains("transcript"))
                .Select(c => c.FileContent)
                .FirstOrDefaultAsync();

            string fileContentStr = fileContent == null ? "" : Encoding.ASCII.GetString(fileContent);

            return MyRegex.NewLineToBr(fileContentStr) ?? string.Empty;
        }

        public ProjectSpecification? GetSpecification(int documentId, int version)
        {
            return _context.ProjectSepcyfications
                .Find(documentId, version);
        }

        public async Task<DocumentDetailsViewModel?> GetDocumentParticipants(int documentId)
        {
            var documentDetails = await (from doc in _context.Documents
                                         join author in _context.Participants
                                            on doc.AuthorId equals author.Id
                                         join teamLeader in _context.Participants
                                            on doc.TeamLeaderId equals teamLeader.Id into tlJoin
                                         from teamLeader in tlJoin.DefaultIfEmpty()
                                         join project in _context.Projects
                                            on doc.ProjectId equals project.Id into pJoin
                                         from project in pJoin.DefaultIfEmpty()
                                         join team in _context.Teams
                                            on doc.TeamId equals team.Id into tJoin
                                         from team in tJoin.DefaultIfEmpty()
                                         where doc.Id == documentId
                                         select new DocumentDetailsViewModel
                                         {
                                             DocumentName = doc.Name,
                                             AuthorName = $"{author.FirstName} {author.LastName}",
                                             TeamLeaderName = $"{teamLeader.FirstName} {teamLeader.LastName}",
                                             ProjectName = project.Name,
                                             TeamName = team.Name
                                         }).FirstOrDefaultAsync();

            return documentDetails;
        }

        public async Task<List<int>> GetAttachements(int id, bool transcriptsOnly)
        {
            List<int> attachementsIdList = [];

            if (transcriptsOnly)
            {
                attachementsIdList = await _context.Attachements
                    .Where (d => d.DocumentId == id)
                    .Where (t => t.IsTranscript)
                    .Select(i => i.Id).ToListAsync();

                return attachementsIdList;
            }

            attachementsIdList = await _context.Attachements
                    .Where(d => d.DocumentId == id)
                    .Select(i => i.Id).ToListAsync();

            return attachementsIdList;
        }

        public async Task UpdateProjectSpecification(int documentId, SRS? documentSrs, Document? document)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                document ??= await _context.Documents.FindAsync(documentId);

                if (document == null)
                {
                    throw new Exception($"Error: document Id:{documentId} not exist.");
                }

                var versionOld = document.Version;

                // Assuming Version is numeric (like an int or double) and needs to be incremented
                document.Version++; // Increment the version
                document.UpdatedDate = DateTime.Now;

                // Save changes
                _context.Update(document);
                await _context.SaveChangesAsync();

                if (documentSrs == null)
                {
                    var projectSpecification = GetSpecification(documentId, versionOld) ?? throw new Exception($"Project specification for document Id: {documentId} not exist.");
                    documentSrs = XamlSerializer.DeserializeObjectToXaml(projectSpecification.XamlContent);

                    var documentDetails = await GetDocumentParticipants(documentId);

                    documentSrs.ProjectName = documentDetails.ProjectName;
                    documentSrs.TeamNumber = documentDetails.TeamName;
                    documentSrs.Owner = documentDetails.TeamLeaderName;
                    documentSrs.Author = documentDetails.AuthorName;
                }

                if (documentSrs == null)
                {
                    throw new Exception($"Deserialize XAML to object error");
                }

                documentSrs.Version = document.Version;
                documentSrs.UpdatedDate = document.UpdatedDate;

                var projectSpecyfication = new ProjectSpecification
                {
                    DocumentId = documentId,
                    Version = documentSrs.Version,
                    CreatedDate = documentSrs.UpdatedDate,
                    
                    // Serialize the SRS object to XAML format
                    XamlContent = XamlSerializer.SerializeObjectToXaml(documentSrs)
                };

                _context.Add(projectSpecyfication);
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                // Rollback if any error occurs
                await transaction.RollbackAsync();
                throw;
            }
        }

        public IEnumerable<DocumentHistoryViewModel> GetDocumentHistories(int documentId)
        {
            var documentHistory = from dh in _context.DocumentHistories
                                  join p in _context.Participants on dh.AuthorId equals p.Id
                                  where dh.DocumentId == documentId
                                  orderby dh.Created descending
                                  select new DocumentHistoryViewModel
                                  {
                                      Description = dh.Description,
                                      Version = dh.Version,
                                      Chapter = dh.Chapter,
                                      Created = dh.Created,
                                      AuthorFullName = p.FirstName + " " + p.LastName,
                                  };



            //var documentHistory = _context.DocumentHistories
            //    .Join(_context.Participants,
            //    h => h.AuthorId,
            //    a => a.Id,
            //    (h, a) => new DocumentHistoryViewModel
            //    {
            //        Description = h.Description,
            //        Version = h.Version,
            //        Chapter = h.Chapter,
            //        Created = h.Created,
            //        AuthorFullName = a.FirstName + " " + a.LastName,
            //    })
            //    .OrderByDescending(d => d.Created);

            return documentHistory;
        }
    }
}
