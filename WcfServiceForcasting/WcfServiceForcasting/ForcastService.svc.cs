using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Http;
using WcfServiceForcasting.models;
using Newtonsoft.Json;
namespace WcfServiceForcasting
{
        public class ForcastService : IForcastService
    {

        public WeatherForecast GetWeatherForecast(string city)
        {
            string apiUrl = "https://api.weatherapi.com/v1/current.json?key=970c660893bf46c882820712232904"+ "&q=" + city;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;

            dynamic weatherData = JsonConvert.DeserializeObject(responseBody);
            WeatherForecast weatherForecast = new WeatherForecast
            {
                City = weatherData.name,
                Country = weatherData.location.country,
                Description = weatherData.current.condition.text,
                Temperature = weatherData.current.temp_c,
                WindSpeed = weatherData.current.wind_kph,
                WindDegree = weatherData.current.wind_degree
            };

            return weatherForecast;
        }
    }
}
