using Newtonsoft.Json;

namespace MoodSync.Models
{
    public abstract class EntityLocation
    {
        [JsonProperty("geometry")]
        public GeometryData Geometry { get; set; }

        public class GeometryData
        {
            [JsonProperty("location")]
            public LocationData Location { get; set; }
        }

        public class LocationData
        {
            [JsonProperty("lat")]
            public double Latitude { get; set; }

            [JsonProperty("lng")]
            public double Longitude { get; set; }
        }
    }
}
