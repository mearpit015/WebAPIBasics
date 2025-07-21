//namespace WebAPIBasics.Attribute;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;

//public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
//{
//    public void OnAuthorization(AuthorizationFilterContext context)
//    {

//        var userName = context.HttpContext.Request.Headers["username"].FirstOrDefault();
//        var password = context.HttpContext.Request.Headers["password"].FirstOrDefault();

//        if (userName != "arpit@015" || password != "pass@015")
//        {
//            context.Result = new UnauthorizedResult();
//        }
//    }

//}

