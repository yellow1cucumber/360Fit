using API.Auth.Exceptions;
using API.Auth.Requests;
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
        private readonly AuthenticationService authenticationService;

        public AuthController(Context context, 
                              AccessTokenService accessTokenService,
                              IdentificationService identificationService,
                              AuthenticationService authenticationService)
        {
            this.accessTokenService = accessTokenService;
            this.identificationService = identificationService;
            this.authenticationService = authenticationService;
        }

        [HttpPost("/auth")]
        public async Task<IResult> AuthUser(AuthenticationRequest request)
        {
            User user;

            try
            {
                user = await this.identificationService.IdentificateUser(request);
            }
            catch (UserNotIdentificatedException ex)
            {
                return Results.NotFound(ex);
            }

            if (!this.authenticationService.AuthenticateUser(request, user))
            {
                return Results.Unauthorized();
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
