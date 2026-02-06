using ProjectLibrary.ASPMVC.Models;
using System.Text.Json;

namespace ProjectLibrary.ASPMVC.Handlers
{
    public class RentSessionManager
    {
        private readonly ISession _session;

        public Dictionary<Guid, RentBookInfos> RentCart
        {
            get {
                if(_session.GetString(nameof(RentCart)) is null)
                {
                    RentCart = new Dictionary<Guid, RentBookInfos>();
                }
                return JsonSerializer.Deserialize<Dictionary<Guid, RentBookInfos>>(_session.GetString(nameof(RentCart))!)!;
            }
            private set {
                if (value is null) throw new ArgumentNullException(nameof(value));
                _session.SetString(nameof(RentCart), JsonSerializer.Serialize(value));
            }
        }

        public RentSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public void AddBook(Guid bookId, string title)
        {
            Dictionary<Guid, RentBookInfos> rentCart = RentCart;
            if (rentCart.ContainsKey(bookId))
            {
                throw new InvalidOperationException("On ne peut emprunter qu'un seul exemplaire de livre");
            }
            rentCart.Add(bookId, new RentBookInfos() { BookId = bookId, Title = title, RentDate = DateTime.Now });
            RentCart = rentCart;
        }

    }
}
