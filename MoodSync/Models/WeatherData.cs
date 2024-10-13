using Newtonsoft.Json;

namespace MoodSync.Models
{
    public class WeatherData
    {
        [JsonProperty("name")]
        public string City { get; set; }

        [JsonProperty("main")]
        public MainData Main { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }

        [JsonProperty("sys")]
        public SysData Sys { get; set; }

        [JsonProperty("weather")]
        public WeatherDescription[] Weather { get; set; }

        public class MainData
        {
            [JsonProperty("temp")]
            public double Temperature { get; set; }

            [JsonProperty("feels_like")]
            public double FeelsLike { get; set; }

            [JsonProperty("temp_min")]
            public double TempMin { get; set; }

            [JsonProperty("temp_max")]
            public double TempMax { get; set; }

            [JsonProperty("humidity")]
            public int Humidity { get; set; }
        }

        public class WindData
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }

            [JsonProperty("deg")]
            public int Degree { get; set; }
        }

        public class WeatherDescription
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }
        }

        public class SysData
        {
            [JsonProperty("country")]
            public string Country { get; set; }
        }
    }
}
