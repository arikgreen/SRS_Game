using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Interfaces;
using SRS_Game.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SRS_Game.Controllers
{
    public class TeamsController : Controller
    {
        private readonly SRS_GameDbContext _context;
        private readonly IReadableParticipant _readableParticipant;

        public TeamsController(SRS_GameDbContext context, IReadableParticipant readableParticipant)
        {
            _context = context;
            _readableParticipant = readableParticipant;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get the user by id
            var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            if (team == null)
            {
                return NotFound();
            }

            // Get members of the team
            var members = await (from participants in _context.Participants
                                 join teamParticipants in _context.TeamParticipants
                                 on participants.Id equals teamParticipants.ParticipantId
                                 where teamParticipants.TeamId == id
                                 select participants).ToListAsync();

            // Create the ViewModel
            var viewModel = new TeamParticipantsViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Number = team.Number,
                Members = members
            };

            return View(viewModel);
        }   

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Number")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get the user by id
            var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            if (team == null)
            {
                return NotFound();
            }

            // Get members of the team 
            var members = await (from participants in _context.Participants
                           join teamParticipants in _context.TeamParticipants
                           on participants.Id equals teamParticipants.ParticipantId
                           where teamParticipants.TeamId == id
                           select participants).ToListAsync();

            // Create the ViewModel
            var viewModel = new TeamParticipantsViewModel
            {
                Id = team.Id,
                Name = team.Name,
                CreatedDate = team.CreatedDate,
                Number = team.Number,
                Members = members,
            };

            ViewBag.Participants = await _readableParticipant.GetParticipantsForSelectListAsync();

            return View(viewModel);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Number,CreatedDate")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Participants = await _readableParticipant.GetParticipantsForSelectListAsync();

            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangeMembers(int id, int participant, string team_action)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    switch(team_action)
                    {
                        case "add":
                            _context.TeamParticipants.Add(new TeamParticipants { TeamId = id, ParticipantId = participant });
                            await _context.SaveChangesAsync();
                            break;
                        
                        case "delete":
                            await _context.TeamParticipants
                                .Where(p => p.ParticipantId == participant && p.TeamId == id)
                                .ExecuteDeleteAsync();
                            break;
                    }
                }
                catch (DbUpdateException ex)
                {
                    // Check if the inner exception is a SqlException
                    // Check for SQL Server error codes for duplicate key; 2627 - Unique constraint error, 2601 - Duplicate key row error
                    if (ex.InnerException != null)
                    {
                        if (((Microsoft.Data.SqlClient.SqlException)ex.InnerException).Number == 2627 || ((Microsoft.Data.SqlClient.SqlException)ex.InnerException).Number == 2601)
                        {
                            // Handle the duplicate key error
                            TempData["Message"] = "Duplicate team member. Cannot insert the same participant";
                        }
                        else
                        {
                            // Other SQL errors can be handled here
                            TempData["Message"] = "A database error occurred";
                        }
                    }
                    else
                    {
                        // Other DbUpdateException errors
                        TempData["Message"] = "An error occurred while updating the database";
                    }
                }
            }
            return RedirectToAction(nameof(Edit), new { Id = id });
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }

        private bool IsMember(int? id)
        {
            return _context.TeamParticipants.Any(e => e.ParticipantId == id);
        }
    }
}
