using MiniAPI.Definitions.Oauth;

namespace MiniAPI.Definitions.Services
{
    public interface IOauthService
    {
        OAuthTokenResponse Authenticate(OAuthTokenRequest request);
        void SignOut();
    }
}
