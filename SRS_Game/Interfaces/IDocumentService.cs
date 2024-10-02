using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Models;
using SRS_Game.Models.Srs;

namespace SRS_Game.Interfaces
{
    public interface IReadableDocument
    {
        IEnumerable<Document> GetAll();
        Task<DocumentViewModel?> GetAsync(int id);
        Task<SelectList> GetDocumentsForSelectListAsync();
        Task<string> GetTranscriptSourceContent(int id);
        Task<List<int>> GetAttachements(int id, bool transcriptsOnly);
        bool DocumentExists(int id);
        ProjectSpecification? GetSpecification(int documentId, int version);
        Task<DocumentDetailsViewModel?> GetDocumentParticipants(int documentId);
        IEnumerable<DocumentHistoryViewModel> GetDocumentHistories(int documentId);
    }
    public interface IWritableDocument
    {
        Task AddAsync(Document document);
        Task UpdateAsync(Document document);
        Task DeleteAsync(int id);
        Task UpdateProjectSpecification(int documentId, SRS? documentSrs, Document? document);
    }
}
