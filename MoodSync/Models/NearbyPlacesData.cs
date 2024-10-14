using Newtonsoft.Json;

namespace MoodSync.Models
{
    public class NearbyPlacesData
    {
        [JsonProperty("results")]
        public List<Place> Results { get; set; }

        public class Place
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("vicinity")]
            public string Vicinity { get; set; }

            [JsonProperty("types")]
            public List<string> Types { get; set; }

        }
    }
}
