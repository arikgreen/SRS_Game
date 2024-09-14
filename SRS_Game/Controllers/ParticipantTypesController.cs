using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SRS_Game.Controllers
{
    public class ParticipantTypesController : Controller
    {
        // GET: ParticipantTypesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParticipantTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticipantTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipantTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParticipantTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParticipantTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
