using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Models;
using SRS_Game.Interfaces;

namespace SRS_Game.Services
{
    public class ProjectService : IReadableProject, IWritableProject
    {
        private readonly SRS_GameDbContext _context;

        public ProjectService(SRS_GameDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public async Task<Project?> GetProjectByIdAsync(int? id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException($"Author with id {id} not found.");
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            /* Code to delete project */
            //throw new NotImplementedException();
        }

        public async Task<SelectList> GetProjectsForSelectListAsync()
        {
            var projects = await _context.Projects
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = String.Format("{0} ({1})", p.Name, p.Number)
                 })
                .ToListAsync();

            projects.Insert(0, new SelectListItem { Value = "", Text = "-- Select an option --" });

            return new SelectList(projects, "Value", "Text");
        }
    }
}
