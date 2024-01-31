using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers;

[ApiController]
[Route("MyController")]
public class WeatherForecastController : ControllerBase
{
    string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet("WeatherForecast")]
    public ActionResult<WeatherForecast> WeatherForecast()
    {
        return Ok("hello");
    }
}
