using System.Text.Json.Serialization;

namespace HttpRequestHandling
{

    public class WeatherResponse
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeather Current { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("tz_id")]
        public string TimeZoneId { get; set; }

        [JsonPropertyName("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("last_updated_epoch")]
        public long LastUpdatedEpoch { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("temp_c")]
        public double TemperatureCelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public double TemperatureFahrenheit { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; } // 1 for day, 0 for night

        [JsonPropertyName("condition")]
        public WeatherCondition Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public double WindMph { get; set; }

        [JsonPropertyName("wind_kph")]
        public double WindKph { get; set; }

        [JsonPropertyName("wind_degree")]
        public int WindDegree { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("pressure_mb")]
        public double PressureMb { get; set; }

        [JsonPropertyName("pressure_in")]
        public double PressureInches { get; set; }

        [JsonPropertyName("precip_mm")]
        public double PrecipitationMm { get; set; }

        [JsonPropertyName("precip_in")]
        public double PrecipitationInches { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int CloudCoverage { get; set; } // Percentage

        [JsonPropertyName("feelslike_c")]
        public double FeelsLikeCelsius { get; set; }

        [JsonPropertyName("feelslike_f")]
        public double FeelsLikeFahrenheit { get; set; }

        // Additional properties for wind chill, heat index, dew point, visibility, UV index, and gusts
        // (if needed)

        // Example:
        // ...
    }

    public class WeatherCondition
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("icon")]
        public string IconUrl { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }

    // Example usage:
    // var weatherData = JsonSerializer.Deserialize<WeatherResponse>(jsonString);
}
