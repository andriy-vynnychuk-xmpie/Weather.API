using Microsoft.AspNetCore.Mvc;
using OpenWeatherMap.Standard;
using Weather.API.Models;

namespace Weather.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> GetWeatherForecast([FromQuery]WeatherRequest request)
        {
            if (request.RequestedDate.AddMinutes(5) < DateTime.Now || request.RequestedDate.AddDays(-5) > DateTime.Now)
            {
                return BadRequest();
            }
            Current currentWeather = new Current(this is secure information please use oyur own API_KEY);
            var forecast = await currentWeather.GetForecastDataByCityNameAsync(request.City);

            if (forecast == null)
            {
                return NotFound();
            }

            var requestForecast = forecast.WeatherData.Last(x => x.AcquisitionDateTime <= request.RequestedDate);

            return Ok(new WeatherForecast(requestForecast));
        }
    }
}