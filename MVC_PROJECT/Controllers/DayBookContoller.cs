using Microsoft.AspNetCore.Mvc;
using MVC_PROJECT.App_Data;
using MVC_PROJECT.Models;
using System.Diagnostics;

namespace MVC_PROJECT.Controllers
{
    [Route("/DayBook")]
    public class DayBookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;
        public DayBookController(ILogger<HomeController> logger, UserContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View("~/Views/Home/DayBook.cshtml");
        }
    }
}