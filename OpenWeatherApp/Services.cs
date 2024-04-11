using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherApp
{
    public class Service
    {
        HttpClient client;


        public Service()
        {
            client = new HttpClient();

        }

        public async Task<WeatherData> GetWeather(string query)
        {
            WeatherData weatherData = null;

            try
            {
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return weatherData;
        }

        internal async Task<WeatherData> GetWeatherData(string v)
        {
            throw new NotImplementedException();
        }
    }
}
