using SRS_Game.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Interfaces;
using SRS_Game.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Text;

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
        
        public async Task<Document?> GetAsync(int id)
        {
            return await _context.Documents.FindAsync(id);
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
            fileContentStr = Regex.Replace(fileContentStr, @"((\r)?\n|\u0010)", "<br />");

            return fileContentStr;
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
    }
}
