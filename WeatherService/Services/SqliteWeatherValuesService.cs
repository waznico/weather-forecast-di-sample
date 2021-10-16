using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.Infrastructure.Database;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class SqliteWeatherValuesService : IWeatherValuesService
    {
        private readonly WeatherForecastContext _context;

        public SqliteWeatherValuesService(WeatherForecastContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> StoreCurrentWeatherValues(IEnumerable<WeatherForecast> forecast)
        {
            await _context.AddRangeAsync(forecast);
            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }
    }
}
