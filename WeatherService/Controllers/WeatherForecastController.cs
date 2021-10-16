using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherService.Models;
using WeatherService.Services;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherValuesService _weatherValuesService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherValuesService weatherValuesService)
        {
            _logger = logger;
            _weatherValuesService = weatherValuesService ?? throw new ArgumentNullException(nameof(weatherValuesService));
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            var weatherValues = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            try
            {
                await _weatherValuesService.StoreCurrentWeatherValues(weatherValues);
            }
            catch
            {
                throw;
            }

            return weatherValues;
        }
    }
}
