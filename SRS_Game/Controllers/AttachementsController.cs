using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Interfaces;
using SRS_Game.Models;
using IFormFile = Microsoft.AspNetCore.Http.IFormFile;

namespace SRS_Game.Controllers
{
    public class AttachementsController : Controller
    {
        private readonly SRS_GameDbContext _context;

        private readonly IReadableDocument _readableDocument;

        public AttachementsController(SRS_GameDbContext context, IReadableDocument readableDocument)
        {
            _context = context;
            _readableDocument = readableDocument;
        }

        // GET: Attachements
        public async Task<IActionResult> Index()
        {
            var orderedAttachements = _context.Attachements
                .Join(_context.Documents,
                a => a.DocumentId,
                d => d.Id,
                (a, d) => new AttachementViewModel {
                    Document = d.Name,
                    Id = a.Id,
                    FileName = a.FileName,
                    ContentType = a.ContentType,
                    CreatedDate = a.CreatedDate,
                    UpdatedDate = a.UpdatedDate
                }
                )
                .OrderByDescending(d => d.CreatedDate)
                .ToListAsync();

            return View(await orderedAttachements);
        }

        // GET: Attachements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachement = await _context.Attachements
                .Join(_context.Documents, 
                a => a.DocumentId,
                d => d.Id,
                (a, d) => new AttachementViewModel 
                { 
                    Document = d.Name,
                    Id = a.Id,
                    FileName = a.FileName,
                    ContentType = a.ContentType,
                    CreatedDate = a.CreatedDate,
                    UpdatedDate = a.UpdatedDate,
                    FileContent = a.FileContent
                })
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (attachement == null || attachement.FileContent == null)
            {
                return NotFound();
            }

            string fileContent = attachement.FileContent == null ? "" : Encoding.ASCII.GetString(attachement.FileContent);
            ViewData["fileContent"] = Regex.Replace(fileContent, @"((\r)?\n|\u0010)", "<br />");

            return View(attachement);
        }

        // GET: Attachements/Create
        public async Task <IActionResult> Create()
        {
            ViewBag.Documents = await _readableDocument.GetDocumentsForSelectListAsync();

            return View("UploadFile");
        }

        // POST: Attachements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,FileName,ContentType,FileContent")] Attachement attachement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attachement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                //var redirectUrl = Url.Action("Details", "Home");

                //return LocalRedirect(redirectUrl);
            }
            return View(attachement);
        }

        [HttpPost]
        public ActionResult UploadFilePost([Bind("DocumentId,file,FileSourceType")] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected for upload...");

            string fileName = Path.GetFileName(file.FileName) ?? "";
            string contentType = file.ContentType;

            try
            {
                using (MemoryStream memoryStream = new())
                {
                    file.CopyToAsync(memoryStream);

                    //byte[] fileContent = new byte[Encoding.GetByteCount(memoryStream)];

                    var attachement = new Attachement[]
                    {
                        new (1, fileName, DateTime.Now, DateTime.Now, memoryStream.ToArray(), contentType)
                    };

                    _context.Attachements.AddRange(attachement);
                    _context.SaveChanges();
                }
            }
            catch
            {
                return BadRequest(new
                {
                    message = "Error saving file to the database."
                });
            }

            return RedirectToAction("Index", "Attachements");
        }

        // GET: Attachements/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var attachement = await _context.Attachements.FindAsync(id);
            if (attachement == null)
            {
                return NotFound();
            }

            ViewBag.Documents = await _readableDocument.GetDocumentsForSelectListAsync();

            return View(attachement);
        }

        // POST: Attachements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DocumentId,FileName,ContentType,CreatedDate")] Attachement attachement)
        {
            if (id != attachement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attachement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttachementExists(attachement.Id))
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

            ViewBag.Documents = await _readableDocument.GetDocumentsForSelectListAsync();
            ViewBag.Message = new Alert { Type = AlertType.danger, Text = "Model state is not valid." };

            return View(attachement);
        }

        // GET: Attachements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachement = await _context.Attachements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attachement == null)
            {
                return NotFound();
            }

            return View(attachement);
        }

        // POST: Attachements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attachement = await _context.Attachements.FindAsync(id);
            if (attachement != null)
            {
                _context.Attachements.Remove(attachement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttachementExists(int id)
        {
            return _context.Attachements.Any(e => e.Id == id);
        }
    }
}
