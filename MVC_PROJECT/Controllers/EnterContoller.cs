using Microsoft.AspNetCore.Mvc;
using MVC_PROJECT.App_Data;
using MVC_PROJECT.Models;
using MVC_PROJECT.Models.Repository;
using MVC_PROJECT.Models.Service;
using System.Diagnostics;
using System.Text;

namespace MVC_PROJECT.Controllers
{
    public class EnterController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public EnterController(ILogger<HomeController> logger, UserContext context)
        {
            _logger = logger;
            _context = context;
            _userRepository = new UserRepository(context);
            _userService = new UserService(_userRepository);
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Enter.cshtml");
        }

        public IActionResult Enter(string login, string password)
        {
            User user = _userService.FindByLoginAndPassword(login,password);
            if (user != null)
            {
                HttpContext.Session.Set("message", Encoding.UTF8.GetBytes("You have been registered"));
                return Redirect("/Home");
            }
            return Index();
        }

    }
}