using HttpRequestHandling.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HttpRequestHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HttpClientFactoryController : ControllerBase
    {
        #region Private properties and Constructors 
        private readonly ILogger<HttpClientFactoryController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWeatherService _weatherService;

        private readonly string _apiKey = "4d3e7e19c9254e03962144751242110";

        public HttpClientFactoryController(ILogger<HttpClientFactoryController> logger, IHttpClientFactory httpClientFactory, IWeatherService weatherService)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _weatherService = weatherService;
        }
        #endregion

        [HttpGet("/HttpClientFactory_1")]
        public async Task<string> HttpClientFactory_1(string cityName = "Noida")
        {
            #region Validate and Sanitize arguements
            #endregion

            var httpClient = _httpClientFactory.CreateClient();
            var URI = $"http://api.weatherapi.com/v1/current.json?key={_apiKey}&q={cityName}";
            
            var response = await httpClient.GetAsync(URI);
            return await response.Content.ReadAsStringAsync();
        }
        
        [HttpGet("/HttpClientFactory_2")]
        public async Task<string> HttpClientFactory_2(string cityName = "Delhi")
        {
            #region Validate and Sanitize arguements
            #endregion

            var httpClient = _httpClientFactory.CreateClient();
            var URI = $"http://api.weatherapi.com/v1/current.json?key={_apiKey}&q={cityName}";

            var response = await httpClient.GetAsync(URI);
            return await response.Content.ReadAsStringAsync();
        }
        
        [HttpGet("/HttpClientFactory_NamedClient")]
        public async Task<string> HttpClientFactory_NamedClient(string cityName = "Delhi")
        {
            #region Validate and Sanitize arguements
            #endregion

            var httpClient = _httpClientFactory.CreateClient("Weather");
            var URI = $"?key={_apiKey}&q={cityName}";

            var response = await httpClient.GetAsync(URI);
            return await response.Content.ReadAsStringAsync();
        }
        
        [HttpGet("/HttpClientFactory_TypedClient")]
        public async Task<string> HttpClientFactory_TypedClient(string cityName = "Delhi")
        {
            return await _weatherService.Get(cityName);
        }
    }
}
