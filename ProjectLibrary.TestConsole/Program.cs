using BE = ProjectLibrary.BLL.Entities;
using BS = ProjectLibrary.BLL.Services;
using DE = ProjectLibrary.DAL.Entities;
using DS = ProjectLibrary.DAL.Services;

namespace ProjectLibrary.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Test Book
            //#region Test DAL
            //DS.BookService dalService = new DS.BookService();
            ///* Test GetAll
            //IEnumerable<Book> library = service.Get();

            //foreach (Book b in library)
            //{
            //    Console.WriteLine($"\"{b.Title}\" écrit par {b.Author}");
            //}
            //*/
            ///* Test GetById
            //Console.WriteLine("Veuillez indiquez un identifiant");
            //Guid id = Guid.Parse(Console.ReadLine());

            //Book book = service.Get(id);

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}");
            //*/
            ///* Test Create
            //Book newBook = new Book();
            //Console.WriteLine("Veuillez indiquer un titre : ");
            //newBook.Title = Console.ReadLine();
            //Console.WriteLine("Veuillez indiquer un Auteur : ");
            //newBook.Author = Console.ReadLine();
            //Console.WriteLine("Veuillez indiquer une Date de sortie : ");
            //newBook.ReleaseDate = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("Veuillez indiquer un ISBN : ");
            //newBook.ISBN = Console.ReadLine();

            //newBook.BookId = service.Create(newBook);

            //newBook = service.Get(newBook.BookId);

            //Console.WriteLine($"Livre bien ajouté le {newBook.RegisteredDate.ToShortDateString()} avec l'identifiant {newBook.BookId}");
            //*/
            ///* Test Update 
            //Console.WriteLine("Veuillez indiquez un identifiant");
            //Guid id = Guid.Parse(Console.ReadLine());

            //Book book = service.Get(id);

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nSorti le {book.ReleaseDate.ToShortDateString()} avec l'ISBN : {book.ISBN}");

            //Console.WriteLine("Veuillez indiquer un nouveau titre : ");
            //book.Title = Console.ReadLine();
            //Console.WriteLine("Veuillez indiquer un nouvel Auteur : ");
            //book.Author = Console.ReadLine();
            //Console.WriteLine("Veuillez indiquer une nouvelle Date de sortie : ");
            //book.ReleaseDate = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("Veuillez indiquer un nouvel ISBN : ");
            //book.ISBN = Console.ReadLine();

            //service.Update(id, book);
            //book = service.Get(id);

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nSorti le {book.ReleaseDate.ToShortDateString()} avec l'ISBN : {book.ISBN}");
            //*/
            ///* Test Delete 
            //Console.WriteLine("Veuillez indiquez un identifiant");
            //Guid id = Guid.Parse(Console.ReadLine());

            //Book book = service.Get(id);

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nSorti le {book.ReleaseDate.ToShortDateString()} avec l'ISBN : {book.ISBN}");

            //service.Delete(id);

            //book = service.Get(id);
            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nSorti le {book.ReleaseDate.ToShortDateString()} avec l'ISBN : {book.ISBN}\nDésactivé le {book.DisabledDate?.ToShortDateString()}");*/
            //#endregion

            //#region Test BLL
            //BS.BookService bllService = new BS.BookService(dalService);
            ///* Test Entité BLL sans DAL 

            //BE.Book book = new BE.Book("La femme de ménage","Freida McFadden", "9782298195453", new DateTime(2022,4,21));

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nAvec l'identifiant {book.BookId}, enregistré le {book.RegisteredDate} avec l'ISBN {book.ISBN}.\nEst sorti le {book.ReleaseDate}, {(book.IsActive?"est disponible" : "est indisponible")}.");

            //book.Disable();

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nAvec l'identifiant {book.BookId}, enregistré le {book.RegisteredDate} avec l'ISBN {book.ISBN}.\nEst sorti le {book.ReleaseDate}, {(book.IsActive ? "est disponible" : "est indisponible")}.");

            //BE.Book book2 = new BE.Book(
            //    Guid.Parse("ABCDEF01-1234-1234-1234-0123456789AB"), 
            //    "Peter Pan, ou le garçon qui ne voulait pas grandir",
            //    "J.M. Barrie",
            //    null,
            //    new DateTime(1904,12,27),
            //    DateTime.Now,
            //    null);

            //Console.WriteLine($"\"{book2.Title}\" écrit par {book2.Author}\nAvec l'identifiant {book2.BookId}, enregistré le {book2.RegisteredDate} avec l'ISBN {book2.ISBN}.\nEst sorti le {book2.ReleaseDate}, {(book2.IsActive ? "est disponible" : "est indisponible")}.");

            //book2.Disable();

            //Console.WriteLine($"\"{book2.Title}\" écrit par {book2.Author}\nAvec l'identifiant {book2.BookId}, enregistré le {book2.RegisteredDate} avec l'ISBN {book2.ISBN}.\nEst sorti le {book2.ReleaseDate}, {(book2.IsActive ? "est disponible" : "est indisponible")}.");
            //*/

            ///* Test GetAll 

            //IEnumerable<BE.Book> library = bllService.Get();

            //foreach (BE.Book b in library)
            //{
            //    Console.WriteLine($"\"{b.Title}\" écrit par {b.Author}\nAvec l'identifiant {b.BookId}, enregistré le {b.RegisteredDate} avec l'ISBN {b.ISBN}.\nEst sorti le {b.ReleaseDate}, {(b.IsActive ? "est disponible" : "est indisponible")}.");
            //}

            //Console.WriteLine("Veuillez indiquez un identifiant");
            //Guid id = Guid.Parse(Console.ReadLine());*/
            ///* Test GetById
            //BE.Book book = bllService.Get(id);

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nAvec l'identifiant {book.BookId}, enregistré le {book.RegisteredDate} avec l'ISBN {book.ISBN}.\nEst sorti le {book.ReleaseDate}, {(book.IsActive ? "est disponible" : "est indisponible")}.");*/
            ///* Test Create
            //Console.WriteLine("Veuillez indiquer un titre : ");
            //string title = Console.ReadLine();
            //Console.WriteLine("Veuillez indiquer un Auteur : ");
            //string? author = Console.ReadLine();
            //Console.WriteLine("Veuillez indiquer une Date de sortie : ");
            //DateTime releaseDate = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("Veuillez indiquer un ISBN : ");
            //string? isbn = Console.ReadLine();

            //BE.Book newBook = new BE.Book(title, author, isbn, releaseDate);

            //Guid bookId = bllService.Create(newBook);

            //newBook = bllService.Get(bookId);

            //Console.WriteLine($"Livre bien ajouté le {newBook.RegisteredDate.ToShortDateString()} avec l'identifiant {newBook.BookId}");
            //*/
            ///* Test Update
            //Console.WriteLine("Veuillez indiquez un identifiant");
            //Guid id = Guid.Parse(Console.ReadLine());

            //BE.Book book = bllService.Get(id);

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nSorti le {book.ReleaseDate.ToShortDateString()} avec l'ISBN : {book.ISBN}");

            //Console.WriteLine("Veuillez indiquer un nouveau titre : ");
            //string title = Console.ReadLine();
            //Console.WriteLine("Veuillez indiquer un nouvel Auteur : ");
            //string? author = Console.ReadLine();
            //Console.WriteLine("Veuillez indiquer une nouvelle Date de sortie : ");
            //DateTime releaseDate = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("Veuillez indiquer un nouvel ISBN : ");
            //string? isbn = Console.ReadLine();

            //book = new BE.Book(book.BookId, title, author, isbn, releaseDate, book.RegisteredDate, book.IsActive ? null : (DateTime?) DateTime.Now);

            //bllService.Update(id, book);
            //book = bllService.Get(id);

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nSorti le {book.ReleaseDate.ToShortDateString()} avec l'ISBN : {book.ISBN}"); */
            ///* Test Delete
            //Console.WriteLine("Veuillez indiquez un identifiant");
            //Guid id = Guid.Parse(Console.ReadLine());

            //BE.Book book = bllService.Get(id);

            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nSorti le {book.ReleaseDate.ToShortDateString()} avec l'ISBN : {book.ISBN}");

            //bllService.Delete(id);

            //book = bllService.Get(id);
            //Console.WriteLine($"\"{book.Title}\" écrit par {book.Author}\nSorti le {book.ReleaseDate.ToShortDateString()} avec l'ISBN : {book.ISBN}\n{(book.IsActive?"Est disponible" : "Est indisponible")}"); */
            //#endregion 
            #endregion

            #region TestUserProfile

            BS.UserProfileService service = new BS.UserProfileService(new DS.UserProfileService());

            IEnumerable<BE.UserProfile> profiles = service.Get();

            foreach (var item in profiles)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
