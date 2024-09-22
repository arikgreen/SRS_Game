using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Models;

namespace SRS_Game.Interfaces
{
    public interface IReadableDocument
    {
        IEnumerable<Document> GetAll();
        Task<Document?> GetAsync(int id);
        Task<SelectList> GetDocumentsForSelectListAsync();
    }
    public interface IWritableDocument
    {
        Task AddAsync(Document document);
        Task UpdateAsync(Document document);
        Task DeleteAsync(int id);
    }
}
