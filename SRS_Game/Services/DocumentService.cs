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
                                  join a in _context.Participants 
                                    on d.AuthorId equals a.Id
                                  where d.Id == id
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
                                      Description = d.Description,
                                      AuthorId = d.AuthorId,
                                      Author = a.FirstName + " " + a.LastName,
                                      TeamId = d.TeamId,
                                      Team = team.Name,
                                      Owner = d.TeamLeaderId.ToString() ?? "",
                                      ProjectId = d.ProjectId,
                                      Project = project.Name,
                                      CreatedDate = d.CreatedDate,
                                      UpdatedDate = d.UpdatedDate,
                                      Version = d.Version,
                                      FileName = d.FileName
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

            documents.Insert(0, new SelectListItem { Value = "", Text = "-- Select an option --" });

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

        public async Task SaveSrsToDatabase(ProjectSpecification srsDocument)
        {
            _context.Add(srsDocument);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVersion(int documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);

            if (document != null)
            {
                // Assuming Version is numeric (like an int or double) and needs to be incremented
                document.Version++; // Increment the version
                document.UpdatedDate = DateTime.Now;

                // Save changes
                await _context.SaveChangesAsync();
            }
        }
    }
}
