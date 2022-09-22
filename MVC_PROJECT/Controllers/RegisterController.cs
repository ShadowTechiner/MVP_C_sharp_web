using Microsoft.AspNetCore.Mvc;
using MVC_PROJECT.App_Data;
using MVC_PROJECT.Models;
using MVC_PROJECT.Models.Exceptions;
using MVC_PROJECT.Models.Service;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Diagnostics;
using MVC_PROJECT.Models.Repository;
using System.Text;

namespace MVC_PROJECT.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly UserContext _context;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public RegisterController(ILogger<RegisterController> logger, UserContext context)
        {
            _logger = logger;
            _context = context;
            _userRepository = new UserRepository(context);
            _userService = new UserService(_userRepository);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Register.cshtml");
        }

        public IActionResult Register(string login, string password)
        {
            User user = default!;
            try
            {
                user = new User();
                user.Login = login;
                user.CreatedDate = DateTime.Now;

                _userService.ValidateRegister(user, password);
                _userService.Register(user, password);

                HttpContext.Session.Set("message", Encoding.UTF8.GetBytes("You have been registered"));
                return Redirect("/Home");
            }
            catch (ValidationException ex)
            {
                ViewData["user"] = user;
                return View("~/Views/Exceptions/ValidationException.cshtml", ex);
            }
        }
    }
}