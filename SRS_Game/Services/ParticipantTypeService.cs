using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Models;
using SRS_Game.Interfaces;

namespace SRS_Game.Services
{
    public class ParticipantTypeService : IReadableParticipantType, IWritableParticipantType
    {
        private readonly SRS_GameDbContext _context;

        public ParticipantTypeService(SRS_GameDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ParticipantType> GetAllParticipantTypes()
        {
            return _context.ParticipantTypes.ToList();
        }

        public async Task<ParticipantType?> GetParticipantTypeByIdAsync(int id)
        {
            return await _context.ParticipantTypes.FindAsync(id);
        }

        public async Task AddAsync(ParticipantType participant)
        {
            _context.ParticipantTypes.Add(participant);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ParticipantType participant)
        {
            _context.ParticipantTypes.Update(participant);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var participant = await _context.ParticipantTypes.FindAsync(id);
            if (participant == null)
            {
                throw new KeyNotFoundException($"Participant type with id {id} not found.");
            }

            _context.ParticipantTypes.Remove(participant);
            await _context.SaveChangesAsync();

            /* Code to delete participant type */
            //throw new NotImplementedException();
        }

        public async Task<SelectList> GetParticipantTypesForSelectListAsync()
        {
            var participantTypes = await _context.ParticipantTypes
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToListAsync();

            participantTypes.Insert(0, new SelectListItem { Value = "", Text = "-- Select an option --" });

            return new SelectList(participantTypes, "Value", "Text");
        }
    }
}
