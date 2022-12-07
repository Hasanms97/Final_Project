using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalAPIController : ControllerBase
    {

        [HttpGet("WeatherByCity/{city}")]
        public async Task<WeatherByCity> WeatherByCity(string city)
        {
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=7a1a9960986d1a1826b7c91ce5d22dfa");
                var stringResult = await response.Content.ReadAsStringAsync();
                var weatherResult = JsonConvert.DeserializeObject<WeatherByCity>(stringResult);
                return weatherResult;
            }
        }
    }
}
