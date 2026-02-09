using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectLibrary.Common.Repositories;

namespace ProjectLibrary.ASPMVC.Handlers.Filters
{
    public class AdministratorFilter : IAuthorizationFilter
    {
        private readonly IUserRepository<BLL.Entities.User> _userService;
        private readonly UserSessionManager _userSession;
        public AdministratorFilter(
            IUserRepository<BLL.Entities.User> userService,
            UserSessionManager userSession)
        {
            _userService = userService;
            this._userSession = userSession;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Guid? userId = _userSession.UserId;
            if(userId is null)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
                return;
            }
            if (!_userService.CheckIsAdministrator((Guid)userId))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
