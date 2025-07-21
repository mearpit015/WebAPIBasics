using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WebAPIBasics.Domains;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeesDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));



//builder.Services.AddAuthentication("BasicAuth")
//    .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuth", null);

//builder.Services.AddAuthorization(o =>
//{
//    o.AddPolicy("Combinatio_CTO_CEO", p => p.RequireRole("CTO", "CEO"));
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
