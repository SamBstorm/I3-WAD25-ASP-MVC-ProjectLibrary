using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectLibrary.ASPMVC.Handlers.Filters
{
    public class HaveRentFilter : IAuthorizationFilter
    {
        private readonly RentSessionManager _rentSession;

        public HaveRentFilter(RentSessionManager rentSession)
        {
            _rentSession = rentSession;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_rentSession.HaveARent)
            {
                context.Result = new RedirectToActionResult("Index","Book",null);
            }
        }
    }
}
