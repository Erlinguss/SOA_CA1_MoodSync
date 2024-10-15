using Newtonsoft.Json;

namespace MoodSync.Models
{
    public class LocationData : EntityLocation
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        public class Result : EntityLocation
        {
        }
    }
}
