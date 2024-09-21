using SRS_Game.Data;
using System.Data.Entity;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace SRS_Game.Services
{
    public interface IReadableDocument
    {
        IEnumerable<Document?> GetAll();
        Task<Document> GetAsync(int? id);
        
    }
    public interface IWritableDocument
    {
        Task AddAsync(Document document);
        Task UpdateAsync(Document document);
        Task DeleteAsync(int id);
    }

    public class DocumentService(SRS_GameDbContext context) : IReadableDocument, IWritableDocument
    {
        private readonly SRS_GameDbContext _context = context;

        public IEnumerable<Document?> GetAll()
        {
            var documents = _context.Documents;

            return (IEnumerable<Document?>)documents;
        }
        
        public Task<Document> GetAsync(int? id)
        {
            /* Code to read specyfication */
            throw new NotImplementedException();
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
