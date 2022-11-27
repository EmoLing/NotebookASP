using Microsoft.AspNetCore.Mvc;
using NotebookASP.Data;
using NotebookASP.Models;
using System.Diagnostics;

namespace NotebookASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NoteDbContext _noteDbContext;

        public HomeController(ILogger<HomeController> logger, NoteDbContext db)
        {
            _logger = logger;
            _noteDbContext = db;
        }

        public IActionResult Index()
        {
            return View(_noteDbContext.Note);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}