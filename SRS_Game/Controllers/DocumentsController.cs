using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Helpers;
using SRS_Game.Interfaces;
using SRS_Game.Models;
using SRS_Game.Models.Srs;

namespace SRS_Game.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly SRS_GameDbContext _context;
        private readonly IReadableParticipant _readableParticipant;
        private readonly IReadableProject _readableProject;
        private readonly IReadableTeam _readableTeam;
        private readonly IReadableAttachement _readableAttachement;
        private readonly IReadableDocument _readableDocument;
        private readonly IWritableDocument _writableDocument;

        public DocumentsController(SRS_GameDbContext context
            , IReadableParticipant readableParticipant
            , IReadableProject readableProject
            , IReadableTeam readableTeam
            , IReadableAttachement readableAttachement
            , IReadableDocument readableDocument
            , IWritableDocument writableDocument)
        {
            _context = context;
            _readableParticipant = readableParticipant;
            _readableProject = readableProject;
            _readableTeam = readableTeam;
            _readableAttachement = readableAttachement;
            _readableDocument = readableDocument;
            _writableDocument = writableDocument;
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
                            Version = document.Version,
                            UpdatedDate = document.UpdatedDate,
                            Author = author.GetParticipantName()
                        }).ToListAsync();

            if (documents == null || documents.Count == 0)
            { 
                return NotFound();
            }

            return View(documents);
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var document = await _readableDocument.GetAsync(id);

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

            var spec = _readableDocument.GetSpecification(id, document.Version);
            if (spec != null)
            {
                string xamlContent = spec.XamlContent;
                //var xaml = System.Windows.Markup.XamlReader.Parse(xamlContent);
                ViewBag.XamlContent = xamlContent; // MyRegex.NewLineToBr(xamlContent);
            }

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
        public async Task<IActionResult> Create(Models.Document document)
        {
            if (ModelState.IsValid)
            {
                document.CreatedDate = DateTime.Now;
                _context.Add(document);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = new Alert { Type = AlertType.danger, Text = "Model state is not valid." };

            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //var document = await _context.Documents.FindAsync(id);

            var document = await _readableDocument.GetAsync(id);
            
            if (document == null)
            {
                return NotFound();
            }

            var stakholderTypes = Enum.GetValues(typeof(StakeholderType))
                .Cast<StakeholderType>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() })
                .ToList();
            
            stakholderTypes.Insert(0, new SelectListItem { Value = "-1", Text = "-- Select an option --" });

            var priorities = Enum.GetValues(typeof(Priority))
                .Cast<Priority>()
                .Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() })
                .ToList();

            priorities.Insert(0, new SelectListItem { Value = "-1", Text = "-- Select an option --" });

            ViewBag.Participants = await _readableParticipant.GetParticipantsForSelectListAsync();
            var projects = await _readableProject.GetProjectsForSelectListAsync();
            ViewBag.Projects = projects;
            var teams = await _readableTeam.GetTeamsForSelectListAsync();
            ViewBag.Teams = teams;
            ViewBag.StakeholderTypes = stakholderTypes;
            ViewBag.Priorities = priorities;

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

            var stakeholder = new Stakeholder {
                Reference = "STKH_001",
                Name = "Zleceniodawca",
                Description = "Organizacja zamawiająca realizację projektu",
                Type = StakeholderType.Corporation,
                FullName = "pełna nazwa dla typu instytucjonalnego",
                AddressOrContact = "adres pocztowy do korespondencji",
                Representative = "STKH_002 Przedstawiciel zleceniodawcy",
                Priority = Priority.medium
            };

            var viewModel = new DocumentEditViewModel
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                ProjectId = document.ProjectId,
                AuthorId = document.AuthorId,
                Author = document.Author,
                Owner = document.Owner,
                Version = document.Version,
                FileName = document.FileName,
                CreatedDate = document.CreatedDate,
                TeamId = document.TeamId,

                SRS = new SRS
                {
                    ProjectName = document.Project ?? "",
                    TeamNumber = document.Team ?? "",
                    Version = document.Version.ToString(),
                    Author = document.Author,
                    Owner = document.Owner,
                    CreatedDate = document.CreatedDate,
                    UpdatedDate = document.UpdatedDate,
                    Stakeholders =
                    [
                        stakeholder
                    ],
                    //Personlesses = [],
                    //BusinesPurposes = [],
                    //FunctionalityPurposes = [],
                    //SystemUsers = [],
                    //ExternalSystems = [],
                    //SubSystems = [],
                    //HardwareComponents = [],
                    //SoftwareComponents = [],
                    //FuncionalityRequirements = [],
                    //DataRequirements = [],
                    //CredibilityRequirements = [],
                    //PerformanceRequirements = [],
                    //FlexibilityRequirements = [],
                    //UsabilityRequirements = [],
                    //Exceptions = [],
                    //CriticalSituations = [],
                    //EmergancySituations = [],
                    //HardwareRequirements = [],
                    //SoftwareRequirements = [],
                    //OtherRequirements = [],
                    //AcceptanceCriteria = [],
                }
            };

            return View(viewModel);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Models.Document document)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    document.Version++;
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_readableDocument.DocumentExists(document.Id) || id != document.Id)
                    {
                        ViewBag.Message = new Alert { Type = AlertType.danger, Text = $"Document Id ({id}) does not exist." };

                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = new Alert { Type = AlertType.danger, Text = "Model state is not valid." };

            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var document = await _readableDocument.GetAsync((int)id);

            if (document != null)
            {
                return View(document);
            }

            ViewBag.Message = new Alert { Type = AlertType.danger, Text = $"Document Id ({id}) does not exist." };

            return NotFound();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveProjectSpecification(DocumentEditViewModel document)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = new Alert { Type = AlertType.danger, Text = "Wrong data" };
                
                return RedirectToAction(nameof(Edit), new { id = document.Id });
            }

            if (document == null || document.SRS == null)
            {
                return NotFound();
            }

            var projectSpecyfication = new ProjectSpecification
            {
                DocumentId = document.Id,
                Name = document.SRS.ProjectName,
                Version = Int32.Parse(document.SRS.Version),
                CreatedDate = DateTime.Now,
                XamlContent = XamlGenerator.GenerateSRSXaml(document.SRS)
            };

            await _writableDocument.SaveSrsToDatabase(projectSpecyfication);

            return RedirectToAction("");
        }
    }
}
