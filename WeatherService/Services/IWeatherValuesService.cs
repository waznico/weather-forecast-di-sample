using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.Models;

namespace WeatherService.Services
{
    public interface IWeatherValuesService
    {
        public Task<bool> StoreCurrentWeatherValues(IEnumerable<WeatherForecast> forecast);
    }
}
