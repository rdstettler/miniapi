using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniAPI.Definitions.Oauth;
using MiniAPI.Definitions.Services;

namespace MiniAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class OauthController : BaseController<IOauthService>
    {
        public OauthController(IOauthService service) : base(service)
        {

        }


        [HttpGet]
        [AllowAnonymous]
        [Route("version")]
        public IActionResult getversion()
        {
            return Ok("version 1.0");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("oauth/token/")]
        public IActionResult Oauthtokenpost(OAuthTokenRequest request)
        {
            OAuthTokenResponse token = service.Authenticate(request);
            return Ok(token);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("oauth/sign-out")]
        public ActionResult Oauthtokenget()
        {
            // basically do nothing, this has to be done on the client side.
            return Ok();
        }
    }
}