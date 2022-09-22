using Microsoft.AspNetCore.Mvc;
using MVC_PROJECT.App_Data;
using MVC_PROJECT.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace MVC_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;
        public string userData = null;
        public HomeController(ILogger<HomeController> logger, UserContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            byte[] userByteData;
            if (HttpContext.Session.TryGetValue("message", out userByteData))
            {
                userData = Encoding.UTF8.GetString(userByteData);
                return View(model:this);
            }
            return View();
        }

        [Route("Home/EnterWelcome/{login}")]
        public IActionResult EnterWelcome(string login)
        {
            ViewBag.Login = login;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}