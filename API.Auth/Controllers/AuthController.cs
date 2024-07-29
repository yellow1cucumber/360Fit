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
        private readonly Context context;
        private readonly Repository<User> userRepository;
        private readonly AccessTokenService accessTokenService;

        public AuthController(Context context, AccessTokenService accessTokenService)
        {
            this.context = context;
            this.userRepository = new Repository<User>(context);

            this.accessTokenService = accessTokenService;
        }

        [HttpPost("/auth")]
        public async Task<IResult> AuthUser(string phone, string password)
        {
            return Results.NotFound();
        }
    }
}
