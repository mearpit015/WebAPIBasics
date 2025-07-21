//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using WebAPIBasics.Attribute;

//namespace WebAPIBasics.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class WeatherForecastController : ControllerBase
//{
//    private static readonly string[] Summaries = new[]
//    {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//    private readonly ILogger<WeatherForecastController> _logger;

//    public WeatherForecastController(ILogger<WeatherForecastController> logger)
//    {
//        _logger = logger;
//    }

//    [HttpGet("GetWeatherForecast")]
//   // [Authorize(Roles = "Admin")]
//    //[CustomAuthorizationAttribute]
//    //[Authorize(Policy = "Combination_OF_CEO_CTO")]
//    public IEnumerable<WeatherForecast> Get()
//    {
//        var user = HttpContext.User;
//        var userName = HttpContext.User.Identity?.Name;

//        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//        {
//            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            TemperatureC = Random.Shared.Next(-20, 55),
//            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//        })
//        .ToArray();
//    }

//    [HttpGet]
//    [AllowAnonymous]
//    public IEnumerable<WeatherForecast> GetWeatherForecast()
//    {

//        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//        {
//            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            TemperatureC = Random.Shared.Next(-20, 55),
//            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//        })
//        .ToArray();
//    }
//}
