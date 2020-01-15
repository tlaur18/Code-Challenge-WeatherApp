using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            HttpResponseMessage response = await httpClient.GetAsync(url + icaoCode);
            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return Ok(jsonString);
            }
            else
            {
                throw new HttpListenerException((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}