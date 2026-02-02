using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Mappers;
using ProjectLibrary.ASPMVC.Models.Book;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC.Controllers
{
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
            IEnumerable<ListItemViewModel> model = _bllService.Get().Select(bll => bll.ToListItem());
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
