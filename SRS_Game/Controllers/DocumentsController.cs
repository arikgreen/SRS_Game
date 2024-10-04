using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<DocumentsController> _localizer;

        public DocumentsController(SRS_GameDbContext context
            , IReadableParticipant readableParticipant
            , IReadableProject readableProject
            , IReadableTeam readableTeam
            , IReadableAttachement readableAttachement
            , IReadableDocument readableDocument
            , IWritableDocument writableDocument, IStringLocalizer<DocumentsController> localizer)
        {
            _context = context;
            _readableParticipant = readableParticipant;
            _readableProject = readableProject;
            _readableTeam = readableTeam;
            _readableAttachement = readableAttachement;
            _readableDocument = readableDocument;
            _writableDocument = writableDocument;
            _localizer = localizer;
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

            document.Attachements = _readableAttachement.GetAllForDocument(id);
            document.History = _readableDocument.GetDocumentHistories(id);

            var spec = _readableDocument.GetSpecification(id, document.Version);
            if (spec != null)
            {
                string xamlContent = spec.XamlContent;
                document.XamlContent = xamlContent;
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

            ViewBag.Participants = await _readableParticipant.GetParticipantsForSelectListAsync();
            ViewBag.Projects = await _readableProject.GetProjectsForSelectListAsync();

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
            
            //stakholderTypes.Insert(0, new SelectListItem { Value = "-1", Text = "-- Select an option --" });

            var priorities = Enum.GetValues(typeof(Priority))
                .Cast<Priority>()
                .Select(x => new SelectListItem { Text = _localizer[x.ToString()], Value = ((int)x).ToString() })
                .ToList();

            //priorities.Insert(0, new SelectListItem { Value = "-1", Text = "-- Select an option --" });

            var participants = await _readableParticipant.GetParticipantsForSelectListAsync();
            var projects = await _readableProject.GetProjectsForSelectListAsync();
            var teams = await _readableTeam.GetTeamsForSelectListAsync();

            ViewBag.Priorities = priorities;
            ViewBag.StakeholderTypes = stakholderTypes;
            ViewBag.Projects = projects;
            ViewBag.Teams = teams;

            var transcriptFileId = await _readableDocument.GetAttachements(id, transcriptsOnly: true);

            if (transcriptFileId != null && transcriptFileId.Count != 0)
            {
                var fileContent = await _readableAttachement.GetContentAsync(transcriptFileId[0]);
                if (fileContent != null)
                {
                    var meetingTranscript = new TranscriptParser(fileContent);

                    ViewData["TopicS"] = meetingTranscript.Topic;
                    ViewData["MeetingDateS"] = meetingTranscript.MeetingDate;
                    ViewData["ParticipantsS"] = MyRegex.NewLineToBr(meetingTranscript.Participants);
                    ViewData["ContentS"] = MyRegex.NewLineToBr(meetingTranscript.MeetingContent);
                }
            }

            SRS? srsDoc = null;
            var spec = _readableDocument.GetSpecification(id, document.Version);
            
            if (spec != null)
            {
                string xamlContent = spec.XamlContent;
                srsDoc = XamlSerializer.DeserializeObjectToXaml(xamlContent);
                //srsDoc.Attachements = _readableAttachement.GetAllForDocument(id).ToList();
                srsDoc.Attachements = [.. _context.Attachements
                    .Where(a => a.DocumentId == id)
                    .OrderBy(a => a.FileName)
                    .Select(a => new SrsAttachement
                    {
                        FileName = a.FileName,
                        ContentType = a.ContentType,
                        CreatedDate = a.CreatedDate
                    })];
            }
            else
            {
                srsDoc = new SRS
                {
                    ProjectName = document.Project ?? "",
                    TeamNumber = document.Team ?? "",
                    Version = document.Version,
                    Author = document.Author,
                    Owner = document.Owner ?? "",
                    CreatedDate = document.CreatedDate,
                    UpdatedDate = document.UpdatedDate,
                };
            }

            var viewModel = new DocumentEditViewModel
            {
                Id = document.Id,
                Name = document.Name,
                Destination = document.Destination,
                ProjectId = document.ProjectId,
                AuthorId = document.AuthorId,
                Author = document.Author,
                Owner = document.Owner,
                Version = document.Version,
                CreatedDate = document.CreatedDate.ToLocalTime(),
                UpdatedDate = document.UpdatedDate.ToLocalTime(),
                TeamId = document.TeamId,
                TeamLeaderId = document.TeamLeaderId,
                History = _readableDocument.GetDocumentHistories(id),
                SRS = srsDoc,
                
                //SRS = new SRS
                //{
                //    ProjectName = document.Project ?? "",
                //    TeamNumber = document.Team ?? "",
                //    Version = document.Version.ToString(),
                //    Author = document.Author,
                //    Owner = document.Owner,
                //    CreatedDate = document.CreatedDate,
                //    UpdatedDate = document.UpdatedDate,
                //    Stakeholders =
                //    [
                //        stakeholder
                //    ],
                //    //Personlesses = [],
                //    //BusinesPurposes = [],
                //    //FunctionalityPurposes = [],
                //    //SystemUsers = [],
                //    //ExternalSystems = [],
                //    //SubSystems = [],
                //    //HardwareComponents = [],
                //    //SoftwareComponents = [],
                //    //FuncionalityRequirements = [],
                //    //DataRequirements = [],
                //    //CredibilityRequirements = [],
                //    //PerformanceRequirements = [],
                //    //FlexibilityRequirements = [],
                //    //UsabilityRequirements = [],
                //    //Exceptions = [],
                //    //CriticalSituations = [],
                //    //EmergancySituations = [],
                //    //HardwareRequirements = [],
                //    //SoftwareRequirements = [],
                //    //OtherRequirements = [],
                //    //AcceptanceCriteria = [],
                //}
            };

            ViewBag.Participants = participants;
            ViewBag.History = _readableDocument.GetDocumentHistories(id);

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
                    await _writableDocument.UpdateProjectSpecification(id, null, document);

                    //document.UpdatedDate = DateTime.Now;
                    //document.Version++;
                    //_context.Update(document);
                    //await _context.SaveChangesAsync();
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

        // POST: Documents/SaveProjectSpecification
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveProjectSpecification(DocumentEditViewModel documentVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = new Alert { Type = AlertType.danger, Text = "Wrong data" };
                
                return RedirectToAction(nameof(Edit), new { id = documentVM.Id });
            }

            if (documentVM == null || documentVM.SRS == null)
            {
                return NotFound();
            }

            SRS document = documentVM.SRS;
            
            await _writableDocument.UpdateProjectSpecification(documentVM.Id, document, null);

            return RedirectToAction(nameof(Edit), new {id = documentVM.Id});
        }
    }
}
