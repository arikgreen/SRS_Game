using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Models;
using SRS_Game.Interfaces;

namespace SRS_Game.Services
{
    public class TeamService : IReadableTeam, IWritableTeam
    {
        private readonly SRS_GameDbContext _context;

        public TeamService(SRS_GameDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        public async Task<Team?> GetTeamByIdAsync(int? id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task AddAsync(Team Team)
        {
            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Team Team)
        {
            _context.Teams.Update(Team);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var Team = await _context.Teams.FindAsync(id);
            if (Team == null)
            {
                throw new KeyNotFoundException($"Author with id {id} not found.");
            }

            _context.Teams.Remove(Team);
            await _context.SaveChangesAsync();

            /* Code to delete Team */
            //throw new NotImplementedException();
        }

        public async Task<SelectList> GetTeamsForSelectListAsync()
        {
            var Teams = await _context.Teams
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = String.Format("{0} ({1})", p.Name, p.Number)
                 })
                .ToListAsync();

            Teams.Insert(0, new SelectListItem { Value = "", Text = "-- Select an option --" });

            return new SelectList(Teams, "Value", "Text");
        }
    }
}
