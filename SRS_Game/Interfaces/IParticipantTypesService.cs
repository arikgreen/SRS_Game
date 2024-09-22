using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Models;

namespace SRS_Game.Interfaces
{
    public interface IReadableParticipantType
    {
        IEnumerable<ParticipantType> GetAllParticipantTypes();
        Task<ParticipantType?> GetParticipantTypeByIdAsync(int id);
        Task<SelectList> GetParticipantTypesForSelectListAsync();

    }

    public interface IWritableParticipantType
    {
        Task AddAsync(ParticipantType participant);
        Task UpdateAsync(ParticipantType participant);
        Task DeleteAsync(int id);
    }
}
