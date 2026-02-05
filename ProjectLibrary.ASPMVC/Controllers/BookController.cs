using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Handlers.Filters;
using ProjectLibrary.ASPMVC.Mappers;
using ProjectLibrary.ASPMVC.Models.Book;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC.Controllers
{
    [TypeFilter<RequiredAuthenticationFilter>]
    public class BookController : Controller
    {
        private readonly IBookRepository<BLL.Entities.Book> _bllService;

        public BookController(IBookRepository<BLL.Entities.Book> bllService)
        {
            _bllService = bllService;
        }

        // GET: BookController
        public ActionResult Index()
        {
            IEnumerable<ListItemViewModel> model;
            // Analyse Hypotétique : traitement de filtrage sans procédure stockée définie
            //if (User.IsAdmin) { 
                model = _bllService.Get().Select(bll => bll.ToListItem());
            //}
            //else {
                //model = _bllService.Get().Where(bll => bll.IsActive).Select(bll => bll.ToListItem());
            //}
            return View(model);
        }

        // GET: BookController/Details/5
        public ActionResult Details(Guid id)
        {
            DetailsViewModel model = _bllService.Get(id).ToDetails();
            return View(model);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide.");
                Guid bookId = _bllService.Create(form.ToBLL());
                return RedirectToAction(nameof(Details),"Book",new {id = bookId});
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(Guid id)
        {
            EditForm model = _bllService.Get(id).ToEdit();
            return View(model);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, EditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide");
                _bllService.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Details),"Book", new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(Guid id)
        {
            DeleteViewModel model = _bllService.Get(id).ToDelete();
            return View(model);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _bllService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
