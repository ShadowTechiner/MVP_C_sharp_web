using Microsoft.AspNetCore.Mvc;
using MVC_PROJECT.App_Data;
using MVC_PROJECT.Models;
using System.Diagnostics;

namespace MVC_PROJECT.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;
        public PhotosController(ILogger<HomeController> logger, UserContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Photos.cshtml");
        }

    }
}