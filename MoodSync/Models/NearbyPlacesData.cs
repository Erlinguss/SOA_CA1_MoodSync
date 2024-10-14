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

            [JsonProperty("geometry")]
            public GeometryData Geometry { get; set; }

            [JsonProperty("photos")]
            public List<PhotoData> Photos { get; set; }
        }

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

        public class PhotoData
        {
            [JsonProperty("photo_reference")]
            public string PhotoReference { get; set; }
        }
    }
}
