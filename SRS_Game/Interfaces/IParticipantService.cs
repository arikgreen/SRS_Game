using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Models;

namespace SRS_Game.Interfaces
{
    public interface IReadableParticipant
    {
        IEnumerable<Participant> GetAllParticipants();
        Task<Participant?> GetParticipantByIdAsync(int id);
        Task<SelectList> GetParticipantsForSelectListAsync();
    }

    public interface IWritableParticipant
    {
        Task AddAsync(Participant participant);
        Task UpdateAsync(Participant participant);
        Task DeleteAsync(int id);
    }
}
