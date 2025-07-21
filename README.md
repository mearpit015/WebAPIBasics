🔐 ASP.NET Core Authentication & Authorization: Custom Middleware vs RequestDelegate vs AuthenticationHandler
This repository demonstrates different implementations of authentication and authorization in ASP.NET Core using:

✅ AuthenticationHandler<TOptions>

✅ RequestDelegate middleware

✅ Custom Middleware

✅ Custom AuthorizationAttribute

✅ Role-based and Policy-based authorization

✅ Claims-based identity

✅ Full CRUD setup with Entity Framework Core


📌 Overview
Authentication and Authorization are essential parts of securing web applications. This project showcases multiple approaches to implement them in ASP.NET Core, comparing their behavior, flexibility, and limitations.

1. 🔧 Custom Middleware (Manual Authentication)
Implements a Middleware class with RequestDelegate.

Manually reads headers/token and sets up the ClaimsPrincipal.

Adds the user to the HttpContext.User.

Limitations:

Requires custom attributes for endpoint-level protection.

The [Authorize] attribute doesn't work because the authentication isn't plugged into the ASP.NET Core authentication pipeline.

Cannot leverage built-in authorization features like roles and policies cleanly.

Hard to maintain and extend.

csharp
Copy
Edit
[CustomAuthorize(Roles = "Admin")]
public IActionResult AdminOnly() => Ok("Hello Admin!");


2. ⚙️ Middleware using RequestDelegate with Identity Setup
Also uses a middleware but registers the ClaimsPrincipal correctly in HttpContext.User.

Enables the use of the [Authorize] attribute at the controller or endpoint level.

Can use policies and roles.

Limitation:

Role-based authorization doesn't behave correctly.

If a user with an invalid role accesses an endpoint with [Authorize(Roles = "Admin")], it returns 200 OK instead of a 403 Forbidden.

This is because the middleware doesn’t correctly integrate with the ASP.NET Core authorization pipeline.


3. 🛡 AuthenticationHandler<TOptions>
Implements AuthenticationHandler<AuthenticationSchemeOptions>.

Fully integrated with the ASP.NET Core security system.

Supports:

[Authorize] with roles and policies

Automatic 403 Forbidden on unauthorized access

Proper token/claims validation

Modular and clean architecture

csharp
Copy
Edit
[Authorize(Roles = "Admin")]
public IActionResult AdminPanel() => Ok("Welcome Admin");


🏗 Program.cs Setup
Using standard ASP.NET Core service configuration for authentication and authorization:

csharp
Copy
Edit
builder.Services.AddAuthentication("CustomScheme")
    .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("CustomScheme", null);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});


Common Features Across All
All implementations demonstrate how to:

Setup and inject ClaimsPrincipal

Add user identity to the HttpContext

Protect endpoints

Use claims for fine-grained authorization



<img width="1094" height="522" alt="image" src="https://github.com/user-attachments/assets/530d0982-c912-45fd-a6cb-6ad3c366f3e1" />
