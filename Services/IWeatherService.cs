namespace HttpRequestHandling.Services
{
    public interface IWeatherService
    {
        Task<string> Get(string cityName);
    }
}
