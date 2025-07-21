//using System.Diagnostics;
//using System.Security.Claims;

//namespace WebAPIBasics.Middleware
//{
//    public class MyAuthorization
//    {
//        private readonly RequestDelegate _next;

//        public MyAuthorization(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            var userName = context.Request.Headers["username"].FirstOrDefault();
//            var password = context.Request.Headers["password"].FirstOrDefault();

//            if (userName == "arpit@015" && password == "pass@015")
//            {
//                var claims = new List<Claim>()
//                {
//                    new Claim(ClaimTypes.Name, userName),
//                    new Claim(ClaimTypes.Role, "Admin")
//                };

//                var identity = new ClaimsIdentity(claims);
//                var principals =  new ClaimsPrincipal(identity);

//                context.User = principals;

//                _next(context);
//            }
//            else
//            {
//                context.Response.StatusCode = 401;
//                await context.Response.WriteAsync("Invalid credentials");
//                return;
//            }
//        }
//    }
//}
