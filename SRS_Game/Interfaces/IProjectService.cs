using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Models;

namespace SRS_Game.Interfaces
{
    public interface IReadableProject
    {
        IEnumerable<Project> GetAllProjects();
        Task<Project?> GetProjectByIdAsync(int? id);
        Task<SelectList> GetProjectsForSelectListAsync();

    }

    public interface IWritableProject
    {
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);
    }
}
