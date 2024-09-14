using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SRS_Game.Data;
using SRS_Game.Models;
using System.Diagnostics;

namespace SRS_Game.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;

        private readonly SRS_GameDbContext _context;

        public ChatController(ILogger<ChatController> logger, SRS_GameDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> DisplayTranscript(int fileId)
        {
            var fileStream = await GetFileFromDb(fileId);
            if (fileStream == null)
            {
                return NotFound("Transcript not found");
            }

            var parsedTranscript = Transcript.ParseTextTranscript(fileStream);
            
            return View(parsedTranscript); 
        }

        [HttpPost]
        public ActionResult UploadFilePost(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected for upload...");

            string fileName = Path.GetFileName(file.FileName);
            string contentType = file.ContentType;

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    file.CopyToAsync(memoryStream);

                    var attachement = new Attachement[]
                    { 
                        new(1, fileName, DateTime.Now, DateTime.Now, memoryStream.ToArray(), contentType)
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

        public async Task<MemoryStream?> GetFileFromDb(int fileId)
        {
            var transcriptFile = await _context.Attachements.FindAsync(fileId);

            if (transcriptFile != null)
            {
                var memoryStream = new MemoryStream(transcriptFile.FileContent);
                return memoryStream;
            } 

            return null; // Handle the case where the file is not found
        }
    }
}
