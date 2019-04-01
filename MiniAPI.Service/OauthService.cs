using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MiniAPI.Definitions;
using MiniAPI.Definitions.Base;
using MiniAPI.Definitions.Oauth;
using MiniAPI.Definitions.Services;
using MiniAPI.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace MiniAPI.Service
{
    public class OauthService : IOauthService
    {
        private readonly AppSettings _appSettings;
        private readonly BaseRepository repository;

        public OauthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            repository = new BaseRepository();
        }

        public OAuthTokenResponse Authenticate(OAuthTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // I use sometimes some sort of default user, if you don't want that, just remove this
            request = CheckForDefault(request);
            User[] users = repository.ReadValue<User[]>("Users");
            if (!users.ToList().Any(s => s.username == request.username))
            {
                return null;
            }


            // Here you should add some sort of password check



            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claimIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, request.username),
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimIdentity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new OAuthTokenResponse()
            {
                access_token = tokenHandler.WriteToken(token),
                token_type = "Jwt Token",
                expires_in = ((DateTimeOffset)tokenDescriptor.Expires.Value).ToUnixTimeSeconds(),
                refresh_token = ""
            };
        }

        public void SignOut()
        {
            // here, I guess we don't have to do anything? Just invalidate the token on the client side???
        }

        private OAuthTokenRequest CheckForDefault(OAuthTokenRequest request)
        {
            if (request.username == null && request.grant_type == "default_token")
            {
                request.username = "default";
                request.password = "";
            }
            return request;
        }
    }
}
