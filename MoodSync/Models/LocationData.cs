using Newtonsoft.Json;

namespace MoodSync.Models
{
    public class LocationData
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        public class Result
        {
            [JsonProperty("geometry")]
            public Geometry Geometry { get; set; }
        }

        public class Geometry
        {
            [JsonProperty("location")]
            public LocationCoordinates Location { get; set; }
        }

        public class LocationCoordinates
        {
            [JsonProperty("lat")]
            public double Latitude { get; set; }

            [JsonProperty("lng")]
            public double Longitude { get; set; }
        }
    }
}
