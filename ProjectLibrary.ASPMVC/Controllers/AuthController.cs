using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Handlers;
using ProjectLibrary.ASPMVC.Handlers.Filters;
using ProjectLibrary.ASPMVC.Mappers;
using ProjectLibrary.ASPMVC.Models.Auth;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository<BLL.Entities.User> _bllService;
        private readonly UserSessionManager _userSession;

        public AuthController(
            IUserRepository<BLL.Entities.User> bllService,
            UserSessionManager userSession)
        {
            _bllService = bllService;
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        [TypeFilter<AnonymousFilter>]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter<AnonymousFilter>]
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
        [TypeFilter<AnonymousFilter>]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter<AnonymousFilter>]
        public IActionResult Login(LoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide.");
                Guid id = _bllService.CheckPassword(form.Email, form.Password);
                _userSession.UserId = id;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [TypeFilter<RequiredAuthenticationFilter>]
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [TypeFilter<RequiredAuthenticationFilter>]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout(IFormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException();
                _userSession.UserId = null;
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
