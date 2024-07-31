using Hikayematik.Data;
using Hikayematik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hikayematik.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context )
        {
            _logger = logger;
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ModelList(string modelName)
        {
            if (modelName == "AniSohbet")
            {
                var list = _context.ani_sohbet.ToList();
                ViewBag.ModelName = "AniSohbet";
                return View(list);
            }
            if (modelName == "Biyografi")
            {
                var list = _context.biyografi.ToList();
                ViewBag.ModelName = "Biyografi";
                return View(list);
            }
            if (modelName == "DeyimHikaye")
            {
                var list = _context.deyim_hikaye.ToList();
                ViewBag.ModelName = "DeyimHikaye";
                return View(list);
            }
            if (modelName == "Drama")
            {
                var list = _context.drama.ToList();
                ViewBag.ModelName = "Drama";
                return View(list);
            }
            if (modelName == "Hikaye")
            {
                var list = _context.hikaye.ToList();
                ViewBag.ModelName = "Hikaye";
                return View(list);
            }
            if (modelName == "Masal")
            {
                var list = _context.masal.ToList();
                ViewBag.ModelName = "Masal";
                return View(list);
            }
            if (modelName == "PratikBilgiler")
            {
                var list = _context.pratik_bilgiler.ToList();
                ViewBag.ModelName = "PratikBilgiler";
                return View(list);
            }
            if (modelName == "Siir")
            {
                var list = _context.siir.ToList();
                ViewBag.ModelName = "Siir";
                return View(list);
            }
            if (modelName == "TarihiYerler")
            {
                var list = _context.tarihi_yerler.ToList();
                ViewBag.ModelName = "TarihiYerler";
                return View(list);
            }

            return NotFound();
        }

        public IActionResult ModelDetail(string modelName, int id)
        {
            if (modelName == "AniSohbet")
            {
                var item = _context.ani_sohbet.Find(id);
                return View(item);
            }
            if (modelName == "Biyografi")
            {
                var item = _context.biyografi.Find(id);
                return View(item);
            }
            if (modelName == "DeyimHikaye")
            {
                var item = _context.deyim_hikaye.Find(id);
                return View(item);
            }
            if (modelName == "Drama")
            {
                var item = _context.drama.Find(id);
                return View(item);
            }
            if (modelName == "Hikaye")
            {
                var item = _context.hikaye.Find(id);
                return View(item);
            }
            if (modelName == "Masal")
            {
                var item = _context.masal.Find(id);
                return View(item);
            }
            if (modelName == "PratikBilgiler")
            {
                var item = _context.pratik_bilgiler.Find(id);
                return View(item);
            }
            if (modelName == "Siir")
            {
                var item = _context.siir.Find(id);
                return View(item);
            }
            if (modelName == "TarihiYerler")
            {
                var item = _context.tarihi_yerler.Find(id);
                return View(item);
            }
            return NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
