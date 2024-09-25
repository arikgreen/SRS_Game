﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Interfaces;
using SRS_Game.Models;

namespace SRS_Game.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly SRS_GameDbContext _context;
        private readonly IReadableParticipant _readableParticipant;
        private readonly IReadableProject _readableProject;
        private readonly IReadableAttachement _readableAttachement;
        private readonly IReadableDocument _readableDocument;

        public DocumentsController(SRS_GameDbContext context
            , IReadableParticipant readableParticipant
            , IReadableProject readableProject
            , IReadableAttachement readableAttachement
            , IReadableDocument readableDocument)
        {
            _context = context;
            _readableParticipant = readableParticipant;
            _readableProject = readableProject;
            _readableAttachement = readableAttachement;
            _readableDocument = readableDocument;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var documents = await (from document in _context.Documents
                        join author in _context.Participants
                        on document.AuthorId equals author.Id
                        join project in _context.Projects
                        on document.ProjectId equals project.Id
                        select new DocumentViewModel
                        {
                            Id = document.Id,
                            Name = document.Name,
                            Project = project.Name,
                            Version = document.VersionId,
                            UpdateDate = document.UpdateDate,
                            Author = author.GetName()
                        }).ToListAsync();

            if (documents == null || documents.Count == 0)
            { 
                return NotFound();
            }

            return View(documents);
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Join(_context.Projects,
                d => d.ProjectId,
                p => p.Id,
                (d, p) => new {
                    d.Id,
                    d.Name,
                    d.VersionId,
                    d.Description,
                    d.CreateDate,
                    d.UpdateDate,
                    d.AuthorId,
                    d.FileName,
                    Project = p.Name
                })
                .Join(_context.Participants,
                d => d.AuthorId,
                a => a.Id,
                (d, a) => new DocumentViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    VersionId = d.VersionId,
                    Description = d.Description,
                    CreateDate = d.CreateDate,
                    UpdateDate = d.UpdateDate,
                    FileName = d.FileName,
                    Project = d.Project,
                    Author = a.FirstName + " " + a.LastName
                })
                .FirstOrDefaultAsync(m => m.Id == id);

            if (document == null)
            {
                return NotFound();
            }

            var attachements = await _context.Attachements.Where(m => m.DocumentId == id)
                .OrderByDescending(d => d.FileName)
                .ToListAsync();

            var docHistory = await _context.DocumentHistories
                .Join(_context.Participants,
                h => h.AuthorId,
                a => a.Id,
                (h, a) => new
                {
                    h.DocumentId,
                    h.Description,
                    h.Created,
                    Author = a.FirstName + " " + a.LastName,
                })
                .Where(m => m.DocumentId == id)
                .OrderByDescending(d => d.Created)
                .ToListAsync();

            ViewBag.Attachements = attachements;
            ViewBag.History = docHistory;

            return View(document);
        }

        // GET: Documents/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Participants = await _readableParticipant.GetParticipantsForSelectListAsync();
            ViewBag.Projects = await _readableProject.GetProjectsForSelectListAsync();

            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProjectName,Description,CreateDate,UpdateDate,Version,FileName,FilePath")] System.Reflection.Metadata.Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            
            if (document == null)
            {
                return NotFound();
            }

            ViewBag.Participants = await _readableParticipant.GetParticipantsForSelectListAsync();
            ViewBag.Projects = await _readableProject.GetProjectsForSelectListAsync();


            var transcriptFileId = await _readableDocument.GetAttachements(id, transcriptsOnly: true);

            if (transcriptFileId != null)
            {
                var fileContent = await _readableAttachement.GetContentAsync(transcriptFileId[0]);
                if (fileContent != null)
                {
                    var meetingTranscript = new TranscriptParser(fileContent);

                    ViewData["TopicS"] = meetingTranscript.Topic;
                    ViewData["MeetingDateS"] = meetingTranscript.MeetingDate;
                    ViewData["ParticipantsS"] = Regex.Replace(meetingTranscript.Participants, @"((\r)?\n|\u0010)", "<br />");
                    ViewData["ContentS"] = Regex.Replace(meetingTranscript.MeetingContent, @"((\r)?\n|\u0010)", "<br />");
                }
            }

            var viewModel = new DocumentEditViewModel
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                ProjectId = document.ProjectId,
                AuthorId = document.AuthorId,
                VersionId = document.VersionId,
                FileName = document.FileName,
                stakeholders = []
            };

            return View(viewModel);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProjectName,Description,CreateDate,UpdateDate,Version,FileName,FilePath")] DocumentEditViewModel document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.Id))
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
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }
    }
}
