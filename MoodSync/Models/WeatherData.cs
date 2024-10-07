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

        [JsonProperty("weather")]
        public WeatherDescription[] Weather { get; set; }

        public class MainData
        {
            [JsonProperty("temp")]
            public double Temperature { get; set; }

            [JsonProperty("humidity")]
            public int Humidity { get; set; }
        }

        public class WindData
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }
        }

        public class WeatherDescription
        {
            [JsonProperty("description")]
            public string Description { get; set; }
        }
    }
}
