using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWeatherApp.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyWeatherApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        private string url = "https://api.foreflight.com/weather/report/";

        [HttpGet]
        public async Task<IActionResult> GetWeather(string icaoCode)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage apiResponse = await httpClient.GetAsync(url + icaoCode);
            if ((int)apiResponse.StatusCode >= 200 && (int)apiResponse.StatusCode < 300)
            {
                string jsonString = await apiResponse.Content.ReadAsStringAsync();
                WeatherDataDTO weatherData = JsonConvert.DeserializeObject<WeatherDataDTO>(jsonString);  //DTO anvendes til at sortere ligegyldigt data fra
                JObject response = new JObject();
                response.Add("conditions", JToken.FromObject(weatherData.report.conditions));
                response.Add("forecast", JToken.FromObject(weatherData.report.forecast));
                return Ok(response.ToString());
            }
            else
            {
                throw new HttpListenerException((int)apiResponse.StatusCode, apiResponse.ReasonPhrase);
            }
        }
    }
}