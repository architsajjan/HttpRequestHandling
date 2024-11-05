using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace HttpRequestHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestSharpController : ControllerBase
    {
        #region Private properties and Constructors 
        private readonly ILogger<RestSharpController> _logger;
        private static readonly RestClient _restClient;

        private readonly string _apiKey = "4d3e7e19c9254e03962144751242110";

        static RestSharpController()
        {
            _restClient = new RestClient("http://api.weatherapi.com/");

            // Optional: Set additional default headers if needed
            _restClient.AddDefaultHeader("User-Agent", "MyApp/1.0");
        }

        public RestSharpController(ILogger<RestSharpController> logger)
        {
            _logger = logger;
            //_restClient = new RestClient("http://api.weatherapi.com/");
        }
        #endregion

        [HttpGet("/RestSharp_Basic")]
        public async Task<IActionResult> RestSharp_Basic(string cityName = "Noida")
        {
            #region Validate and Sanitize arguements
            #endregion

            var request = new RestRequest($"/v1/current.json?key={_apiKey}&q={cityName}", Method.Get);

            var restResponse = await _restClient.ExecuteAsync(request);

            if (restResponse.IsSuccessful)
            {
                var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(restResponse.Content);
                return Ok(weatherResponse);
            }
            else
            {
                return StatusCode((int)restResponse.StatusCode, new { message = "Error fetching weather data." });
            }
        }
        
        [HttpGet("/RestSharp_Batch")]
        public async Task<IActionResult> RestSharp_Batch([FromQuery] string[] cityNames)
        {
            var tasks = new List<Task<WeatherResponse>>();

            foreach (var cityName in cityNames)
            {
                var request = new RestRequest($"/v1/current.json", Method.Get);
                request.AddQueryParameter("key", _apiKey);
                request.AddQueryParameter("q", cityName);

                tasks.Add(_restClient.ExecuteAsync(request).ContinueWith(restTask =>
                {
                    if (restTask.Result.IsSuccessful)
                    {
                        return JsonSerializer.Deserialize<WeatherResponse>(restTask.Result.Content);
                    }
                    else
                    {
                        return null; // Handle error case appropriately
                    }
                }) as Task<WeatherResponse>);
            }

            var responses = await Task.WhenAll(tasks);
            var validResponses = responses.Where(r => r != null).ToArray();

            return Ok(validResponses);
        }
    }
}
