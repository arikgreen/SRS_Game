using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Interfaces;
using SRS_Game.Models;

namespace SRS_Game.Services
{
    public class ParticipantService : IReadableParticipant, IWritableParticipant
    {
        private readonly SRS_GameDbContext _context;

        public ParticipantService(SRS_GameDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Participant> GetAllParticipants()
        {
            return [.. _context.Participants];
        }

        public async Task<Participant?> GetParticipantByIdAsync(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public async Task AddAsync(Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Participant participant)
        {
            _context.Participants.Update(participant);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                throw new KeyNotFoundException($"Author with id {id} not found.");
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            /* Code to delete participant */
            //throw new NotImplementedException();
        }

        public async Task<SelectList> GetParticipantsForSelectListAsync()
        {
            var participants = await _context.Participants
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.FirstName + " " + p.LastName
                })
                .ToListAsync();

            participants.Insert(0, new SelectListItem { Value = "", Text = "-- Select an option --" });

            return new SelectList(participants, "Value", "Text");
        }
    }
}
