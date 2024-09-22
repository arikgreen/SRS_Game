﻿using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SRS_Game.Data;
using SRS_Game.Interfaces;
using SRS_Game.Models;

namespace SRS_Game.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly SRS_GameDbContext _context;
        private readonly IReadableParticipantType _readableParticipantType;

        public ParticipantsController(SRS_GameDbContext context, IReadableParticipantType readableParticipantType)
        {
            _context = context;
            _readableParticipantType = readableParticipantType;
        }

        // GET: Participant
        public async Task<IActionResult> Index()
        {
            var participants = await _context.Participants
                .Join(_context.ParticipantTypes, 
                p => p.TypeId,                  // key from Participants table
                t => t.Id,                      // key from ParticipantTypes table
                static (p, t) => new ParticipantViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    Type = t.Name
                }).ToListAsync();
            
            return View(participants);
        }

        // GET: Participant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .Join(_context.ParticipantTypes, 
                p => p.TypeId, 
                t => t.Id, 
                (p, t) => new ParticipantViewModel 
                {
                    Id = p.Id,
                    Name = p.Name,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    Type = t.Name,
                    Address = p.GetAddress()
                })
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();
            
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participant/Create
        public async Task<IActionResult> Create()
        {
            var participantTypes = await _readableParticipantType.GetParticipantTypesForSelectListAsync();

            ViewBag.ParticipantTypes = participantTypes;

            return View();
        }

        // POST: Participant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FirstName,LastName,Email,PhoneNumber,Address,TypeId")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(participant);
        }

        // GET: Participant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return View(participant);
        }

        // POST: Participant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProjectName,Description,CreateDate,UpdateDate,Version,FileName,FilePath")] Participant participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(participant.Id))
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
            return View(participant);
        }

        // GET: Participant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}
