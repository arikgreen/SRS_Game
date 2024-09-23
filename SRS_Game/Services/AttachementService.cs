using SRS_Game.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Interfaces;
using SRS_Game.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Text;

namespace SRS_Game.Services
{
    public class AttachementService : IReadableAttachement, IWritableAttachement
    {
        private readonly SRS_GameDbContext _context;

        public AttachementService(SRS_GameDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attachement> GetAll()
        {
            return [.. _context.Attachements];
        }
        
        public async Task<Attachement?> GetAsync(int id)
        {
            return await _context.Attachements.FindAsync(id);
        }

        public async Task<SelectList> GetAttachementsForSelectListAsync()
        {
            var attachements = await _context.Attachements
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.FileName
                })
                .ToListAsync();

            attachements.Insert(0, new SelectListItem { Value = "", Text = "-- Select an option --" });

            return new SelectList(attachements, "Value", "Text");
        }

        public Task AddAsync(Attachement attachement)
        {
            /* Code to add attachement */
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Attachement attachement)
        {
            /* Code to update attachement */
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            /* Code to delete attachement */
            throw new NotImplementedException();
        }

        public async Task<string> GetTranscriptSourceContentAsync(int docId)
        { 
            var fileContent = await _context.Attachements
                .Where(d => d.DocumentId == docId)
                .Where(o => o.IsTranscript == true)
                .Select(c => c.FileContent)
                .FirstOrDefaultAsync();

            string fileContentStr = fileContent == null ? "" : Encoding.ASCII.GetString(fileContent);
            fileContentStr = Regex.Replace(fileContentStr, @"((\r)?\n|\u0010)", "<br />");

            return fileContentStr;
        }

        public async Task<byte[]?> GetContentAsync(int id)
        {
            var fileContent = await _context.Attachements
                .Where(d => d.Id == id)
                .Select(c => c.FileContent)
                .FirstOrDefaultAsync();

            return fileContent;
        }
    }
}
