using HookahNet.Controllers.DBContexts;
using Microsoft.AspNetCore.Mvc;

namespace HookahNet.Controllers
{
    public class AccountController : Controller
    {
        private GuestUserContext guestUserContext;
        public AccountController(GuestUserContext guestUserContext)
        {
            this.guestUserContext = guestUserContext;
        }


    }
}
