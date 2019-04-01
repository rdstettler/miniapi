using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MiniAPI.Controllers
{
    [ApiController]
    public class BaseController<S> : ControllerBase
    {
        protected S service;
        
        public BaseController(S service)
        {
            this.service = service;
        }

        protected readonly UserManager<IdentityUser> _userManager;
    }
}