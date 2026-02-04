using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Mappers;
using ProjectLibrary.ASPMVC.Models.Auth;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository<BLL.Entities.User> _bllService;

        public AuthController(IUserRepository<BLL.Entities.User> bllService)
        {
            _bllService = bllService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            try
            {
                if (!form.AgreeTerms) ModelState.AddModelError(nameof(form.AgreeTerms), "Les conditions doivent être acceptées.");
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide.");
                Guid userId = _bllService.Create(form.ToBLL());
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide.");
                Guid id = _bllService.CheckPassword(form.Email, form.Password);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
