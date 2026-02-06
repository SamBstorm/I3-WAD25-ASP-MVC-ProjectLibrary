using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.ASPMVC.Handlers;
using ProjectLibrary.ASPMVC.Handlers.Filters;
using ProjectLibrary.ASPMVC.Mappers;
using ProjectLibrary.ASPMVC.Models.Rent;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC.Controllers
{
    public class RentController : Controller
    {
        private readonly IBookRepository<BLL.Entities.Book> _bookService;
        private readonly RentSessionManager _rentSessionManager;

        public RentController(
            IBookRepository<BLL.Entities.Book> bookService, 
            RentSessionManager rentSessionManager)
        {
            _bookService = bookService;
            _rentSessionManager = rentSessionManager;
        }

        [TypeFilter<HaveRentFilter>]
        public IActionResult Index()
        {
            /*IEnumerable<ListItemViewModel> model = _rentSessionManager.RentCart.Values.Select(val => val.ToListItem());*/
            IEnumerable<ListItemViewModel> model = _rentSessionManager.RentCart.Keys.Select(key => _bookService.Get(key).ToRentListItem());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Guid bookId)
        {
            try
            {
                //Récupération du livre par le service
                BLL.Entities.Book bookToRent = _bookService.Get(bookId);
                //Sauvegarde du livre dans la session
                _rentSessionManager.AddBook(bookId, bookToRent.Title);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(Guid bookId)
        {
            try
            { 
                //Supprimer le livre dans la session
                _rentSessionManager.RemoveBook(bookId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
