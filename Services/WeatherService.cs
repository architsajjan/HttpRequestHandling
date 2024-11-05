namespace HttpRequestHandling.Services
{
    public class WeatherService : IWeatherService
    {
        private HttpClient _httpClient;
        private readonly string _apiKey = "4d3e7e19c9254e03962144751242110";


        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get(string cityName)
        {
            #region Validate and Sanitize arguements
            #endregion

            string URI = $"?key={_apiKey}&q={cityName}";

            var response = await _httpClient.GetAsync(URI);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
