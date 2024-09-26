using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Models;

namespace SRS_Game.Interfaces
{
    public interface IReadableTeam
    {
        IEnumerable<Team> GetAllTeams();
        Task<Team?> GetTeamByIdAsync(int? id);
        Task<SelectList> GetTeamsForSelectListAsync();

    }

    public interface IWritableTeam
    {
        Task AddAsync(Team Team);
        Task UpdateAsync(Team Team);
        Task DeleteAsync(int id);
    }
}
