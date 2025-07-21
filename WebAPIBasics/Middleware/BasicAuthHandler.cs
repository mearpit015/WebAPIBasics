//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Options;
//using System.Security.Claims;
//using System.Text.Encodings.Web;

//namespace WebAPIBasics.Middleware
//{
//    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder,
//             ISystemClock clock) 
//            : base(options, logger, encoder, clock)
//        {
//        }

//        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            var userName = Request.Headers["username"].FirstOrDefault();
//            var password = Request.Headers["password"].FirstOrDefault();

//            if (userName == "arpit@015" && password == "pass@015")
//            {
//                var claims = new List<Claim>()
//                {
//                    new Claim(ClaimTypes.Name, userName),
//                    new Claim(ClaimTypes.Role, "Admin")
//                };

//                var identity = new ClaimsIdentity(claims);
//                var principals = new ClaimsPrincipal(identity);

//                // Context.User = principals;
//                var tickets = new AuthenticationTicket(principals, "BasicAuth");

//               return Task.FromResult(AuthenticateResult.Success(tickets));
//            }
//            else
//            {
//                return Task.FromResult(AuthenticateResult.Fail(new UnauthorizedAccessException("Invalid userName and password")));
//            }
//        }
//    }
//}
