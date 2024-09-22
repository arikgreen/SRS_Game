using SRS_Game.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Interfaces;
using SRS_Game.Models;

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
    }
}
