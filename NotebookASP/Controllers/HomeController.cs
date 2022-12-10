using Microsoft.AspNetCore.Mvc;
using NotebookASP.Data;
using NotebookASP.Models;
using NotebookASP.Models.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NotebookASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoteRepository _db;

        public HomeController(ILogger<HomeController> logger, INoteRepository db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.GetAllNotes());
        }

        public IActionResult CreateNote()
        {
            return RedirectToAction("Upsert");
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id) => View(await _db.GetNote(id));

        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> Upsert(Note note)
        {
            if (note.ID == 0)
                await _db.CreateNote(note);
            else
                await _db.UpdateNote(note);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
            => await _db.DeleteNote(id) ? RedirectToAction(nameof(Index)) : BadRequest();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}