using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Models;

namespace SRS_Game.Interfaces
{
    public interface IReadableAttachement
    {
        IEnumerable<Attachement> GetAll();
        Task<Attachement?> GetAsync(int id);
        Task<SelectList> GetAttachementsForSelectListAsync();
        Task<string?> GetTranscriptSourceContentAsync(int id);
        Task<byte[]?> GetContentAsync(int id);
    }
    public interface IWritableAttachement
    {
        Task AddAsync(Attachement attachement);
        Task UpdateAsync(Attachement attachement);
        Task DeleteAsync(int id);
    }
}
