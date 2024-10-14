using Newtonsoft.Json;

namespace MoodSync.Models
{
    public class NearbyPlacesData
    {
        [JsonProperty("results")]
        public List<Place> Results { get; set; }

        [JsonProperty("html_attributions")]
        public List<string> HtmlAttributions { get; set; }

        public class Place
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("vicinity")]
            public string Vicinity { get; set; }

            [JsonProperty("types")]
            public List<string> Types { get; set; }

            [JsonProperty("photos")]
            public List<Photo> Photos { get; set; }

           /* [JsonProperty("geometry")]
            public Geometry Geometry { get; set; }*/
        }

    /*    public class Geometry
        {
            [JsonProperty("location")]
            public LocationCoordinates Location { get; set; }
        }*/

/*        public class LocationCoordinates
        {
            [JsonProperty("lat")]
            public double Latitude { get; set; }

            [JsonProperty("lng")]
            public double Longitude { get; set; }
        }*/
        public class Photo
        {
            [JsonProperty("html_attributions")]
            public List<string> HtmlAttributions { get; set; }
        }
    }
}
