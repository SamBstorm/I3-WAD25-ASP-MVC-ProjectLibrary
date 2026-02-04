using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Mappers;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserProfileRepository<BLL.Entities.UserProfile> _userProfileService;

        public UserProfileController(IUserProfileRepository<BLL.Entities.UserProfile> userProfileService)
        {
            _userProfileService = userProfileService;
        }

        // GET: UserProfileController
        public ActionResult Index()
        {
            IEnumerable<Models.UserProfile.ListItemViewModel> model = _userProfileService.Get().Select(bll => bll.ToListItem());
            return View(model);
        }

        // GET: UserProfileController/Details/5
        public ActionResult Details(Guid id)
        {
            Models.UserProfile.DetailsViewModel model = _userProfileService.Get(id).ToDetails();
            return View(model);
        }

        // GET: UserProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.UserProfile.CreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide.");
                Guid id = _userProfileService.Create(form.ToBLL());
                return RedirectToAction(nameof(Edit), "UserProfile", new {id});
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfileController/Edit/5
        public ActionResult Edit(Guid id)
        {
            BLL.Entities.UserProfile entity = _userProfileService.Get(id);
            //ViewData["UserName"] = $"{entity.LastName} {entity.FirstName}";
            Models.UserProfile.EditForm model = entity.ToEdit();
            return View(model);
        }

        // POST: UserProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Models.UserProfile.EditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide.");
                _userProfileService.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Details), "UserProfile", new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfileController/Delete/5
        public ActionResult Delete(Guid id)
        {
            Models.UserProfile.DeleteViewModel model = _userProfileService.Get(id).ToDelete();
            return View(model);
        }

        // POST: UserProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _userProfileService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
