using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoodSync.Models
{
    public class LocationData
    {
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
