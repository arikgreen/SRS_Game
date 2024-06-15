using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Models;

namespace SRS_Game.Controllers
{
    public class AttachementsController : Controller
    {
        private readonly SRS_GameDbContext _context;

        public AttachementsController(SRS_GameDbContext context)
        {
            _context = context;
        }

        // GET: Attachements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attachements.ToListAsync());
        }

        // GET: Attachements/Details/5
        public async Task<IActionResult> Details(int? id)
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

            ViewData["fileContent"] = attachement.FileContent == null ? "" : Encoding.UTF8.GetString(attachement.FileContent);

            return View(attachement);
        }

        // GET: Attachements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attachements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DocumentId,FileName,ContentType,FileContent,CreateDate,UpdateDate")] Attachement attachement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attachement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attachement);
        }

        // GET: Attachements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachement = await _context.Attachements.FindAsync(id);
            if (attachement == null)
            {
                return NotFound();
            }
            return View(attachement);
        }

        // POST: Attachements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DocumentId,FileName,ContentType,FileContent,CreateDate,UpdateDate")] Attachement attachement)
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
