using API.Auth.Exceptions;
using API.Auth.Services;
using DAL;
using Domain.Core.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AccessTokenService accessTokenService;
        private readonly IdentificationService identificationService;

        public AuthController(Context context, 
                              AccessTokenService accessTokenService,
                              IdentificationService identificationService)
        {
            this.accessTokenService = accessTokenService;
            this.identificationService = identificationService;
        }

        [HttpPost("/auth")]
        public async Task<IResult> AuthUser(string phone, string password)
        {
            User user;
            try
            {
                user = await this.identificationService.IdentificateUser(phone);
            }
            catch (UserNotIdentificatedException ex)
            {
                return Results.NotFound(ex);
            }

            var token = this.accessTokenService.GenerateToken(user);
            return Results.Ok(
                new {
                    token = token,
                    user = user,
                });
        }
    }
}
