using Microsoft.AspNetCore.Mvc;
using ProjectLibrary.BLL.Entities;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository<BLL.Entities.Category> _categoryService;
        private readonly IBookRepository<BLL.Entities.Book> _bookService;

        public CategoryController(
            ICategoryRepository<Category> categoryService, 
            IBookRepository<Book> bookService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Index),"Home");
        }

        [HttpPost]
        public IActionResult CategoryManager(Guid bookId, string submit)
        {
            if(submit == "+")
            {
                return RedirectToAction("AddCategory", "Category", new {bookId});
            }
            else if(submit == "-")
            {
                return RedirectToAction("RemoveCategory", "Category", new { bookId });
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult AddCategory(Guid bookId)
        {
            IEnumerable<BLL.Entities.Category> bookCategories = _categoryService.GetByBook(bookId);
            IEnumerable<BLL.Entities.Category> allCategories = _categoryService.Get();
            IEnumerable<BLL.Entities.Category> model = allCategories.ExceptBy(bookCategories.Select(bc => bc.CategoryId), cat => cat.CategoryId);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCategory(Guid bookId, int categoryId)
        {
            try
            {
                _bookService.AddCategory(bookId, categoryId);
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult RemoveCategory(Guid bookId)
        {
            IEnumerable<BLL.Entities.Category> model = _categoryService.GetByBook(bookId);
            return View(model);
        }

        [HttpPost]
        public IActionResult RemoveCategory(Guid bookId, int categoryId)
        {
            try
            {
                _bookService.RemoveCategory(bookId, categoryId);
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
