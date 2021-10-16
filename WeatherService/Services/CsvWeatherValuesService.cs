using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class CsvWeatherValuesService : IWeatherValuesService
    {
        private readonly string _csvFilePath;

        public CsvWeatherValuesService()
        {
            var destDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "weather_forecast");

            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            _csvFilePath = Path.Combine(destDir, "forecast.csv");
        }

        public async Task<bool> StoreCurrentWeatherValues(IEnumerable<WeatherForecast> forecast)
        {
            var headline = string.Join(';', "Date", "Summary", "Temperature in Celcius", "Temperature in Fahrenheiit");
            var fileContent = new List<string>();
            fileContent.Add(headline);

            foreach (var entry in forecast)
            {
                var result = string.Join(';', entry.Date, entry.Summary, entry.TemperatureC, entry.TemperatureF);
                fileContent.Add(result);
            }

            await File.WriteAllLinesAsync(_csvFilePath, fileContent, System.Text.Encoding.UTF8);
            return true;
        }
    }
}
