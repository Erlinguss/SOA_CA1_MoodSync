/*using MoodSync.Enums;
using MoodSync.Interfaces;
using MoodSync.Models;

namespace MoodSync.Services
{
    public class RecommendationService
    {
        private readonly IWeatherService _weatherService;
        private readonly ILocationService _locationService;
        private readonly IGeoCodingService _geocodingService;

        public RecommendationService(IWeatherService weatherService, ILocationService locationService, IGeoCodingService geocodingService)
        {
            _weatherService = weatherService;
            _locationService = locationService;
            _geocodingService = geocodingService;
        }

        public async Task<List<string>> GetRecommendationsAsync(string location, Mood mood)
        {
            var weatherData = await _weatherService.GetWeatherAsync(location);

            var geocodeData = await _geocodingService.GetCoordinatesAsync(location);

            if (geocodeData != null && geocodeData.Results.Count > 0)
            {
                var latitude = geocodeData.Results[0].Geometry.Location.Latitude;
                var longitude = geocodeData.Results[0].Geometry.Location.Longitude;

                var nearbyPlacesData = await _locationService.GetNearbyPlacesAsync(latitude, longitude);

                return FilterPlacesByMood(nearbyPlacesData, mood);
            }
            return new List<string> { "Unable to retrieve location data. Please try again." };
        }

        private List<string> FilterPlacesByMood(NearbyPlacesData nearbyPlaces, Mood mood)
        {
            var filterRecommendations = new List<string>();

            foreach (var place in nearbyPlaces.Results)
            {
                if (IsPlaceSuitableForMood(place, mood))
                {
                    filterRecommendations.Add($"{place.Name} - {place.Vicinity}");
                }
            }
            return filterRecommendations;
        }

        private bool IsPlaceSuitableForMood(NearbyPlacesData.Place place, Mood mood)
        {
            switch (mood)
            {
                case Mood.Happy:
                    return place.Name.Contains("park") || place.Name.Contains("garden") || place.Name.Contains("playground");
                case Mood.Sad:
                    return place.Name.Contains("cafe") || place.Name.Contains("restaurant") || place.Name.Contains("movie");
                case Mood.Angry:
                    return place.Name.Contains("gym") || place.Name.Contains("boxing") || place.Name.Contains("martial arts");
                case Mood.Stressed:
                    return place.Name.Contains("spa") || place.Name.Contains("massage") || place.Name.Contains("yoga");
                case Mood.Relaxed:
                    return place.Name.Contains("beach") || place.Name.Contains("lake") || place.Name.Contains("mountain");
                default:
                    return false;
            }
        }
    }
}

*/

using MoodSync.Enums;
using MoodSync.Interfaces;
using MoodSync.Models;

namespace MoodSync.Services
{
    public class RecommendationService
    {
        private readonly IWeatherService _weatherService;
        private readonly ILocationService _locationService;
        private readonly IGeoCodingService _geocodingService;

        public RecommendationService(IWeatherService weatherService, ILocationService locationService, IGeoCodingService geocodingService)
        {
            _weatherService = weatherService;
            _locationService = locationService;
            _geocodingService = geocodingService;
        }

        public async Task<List<string>> GetRecommendationsAsync(string location, Mood mood)
        {

            var weatherData = await _weatherService.GetWeatherAsync(location);
            if (weatherData == null)
            {
                return new List<string> { "No weather data available." };
            }

            var geocodeData = await _geocodingService.GetCoordinatesAsync(location);
            if (geocodeData == null || geocodeData.Results.Count == 0)
            {
                return new List<string> { "Unable to retrieve geocoding data." };
            }

            var latitude = geocodeData.Results[0].Geometry.Location.Latitude;
            var longitude = geocodeData.Results[0].Geometry.Location.Longitude;

            var nearbyPlacesData = await _locationService.GetNearbyPlacesAsync(latitude, longitude);
            if (nearbyPlacesData == null || nearbyPlacesData.Results.Count == 0)
            {
                return new List<string> { "No nearby places found." };
            }

            return FilterPlacesByMood(nearbyPlacesData, mood);
        }

        private List<string> FilterPlacesByMood(NearbyPlacesData nearbyPlaces, Mood mood)
        {
            var filteredRecommendations = new List<string>();

            foreach (var place in nearbyPlaces.Results)
            {
                if (IsPlaceSuitableForMood(place, mood))
                {
                    filteredRecommendations.Add($"{place.Name} - {place.Vicinity}");
                }
            }

            if (filteredRecommendations.Count == 0)
            {
                return new List<string> { "No places matched your mood." };
            }

            return filteredRecommendations;
        }


        private bool IsPlaceSuitableForMood(NearbyPlacesData.Place place, Mood mood)
        {
            var lowerCaseName = place.Name.ToLower();

            switch (mood)
            {
                case Mood.Happy:
                    return lowerCaseName.Contains("park") || lowerCaseName.Contains("cafe") || lowerCaseName.Contains("restaurant") ||
                           lowerCaseName.Contains("bar") || lowerCaseName.Contains("pub") || lowerCaseName.Contains("amusement") ||
                           lowerCaseName.Contains("playground") || lowerCaseName.Contains("beach") || lowerCaseName.Contains("arcade") ||
                           lowerCaseName.Contains("garden") || lowerCaseName.Contains("zoo");

                case Mood.Sad:
                    return lowerCaseName.Contains("cinema") || lowerCaseName.Contains("movie") || lowerCaseName.Contains("theater") ||
                           lowerCaseName.Contains("entertainment") || lowerCaseName.Contains("museum") || lowerCaseName.Contains("cultural") ||
                           lowerCaseName.Contains("art") || lowerCaseName.Contains("gallery") || lowerCaseName.Contains("landmark") ||
                           lowerCaseName.Contains("exhibition");

                case Mood.Stressed:
                    return lowerCaseName.Contains("spa") || lowerCaseName.Contains("garden") || lowerCaseName.Contains("library") ||
                           lowerCaseName.Contains("nature") || lowerCaseName.Contains("retreat") || lowerCaseName.Contains("resort") ||
                           lowerCaseName.Contains("massage") || lowerCaseName.Contains("wellness") || lowerCaseName.Contains("yoga") ||
                           lowerCaseName.Contains("meditation") || lowerCaseName.Contains("relaxation");

                case Mood.Relaxed:
                    return lowerCaseName.Contains("museum") || lowerCaseName.Contains("viewpoint") || lowerCaseName.Contains("park") ||
                           lowerCaseName.Contains("lake") || lowerCaseName.Contains("beach") || lowerCaseName.Contains("nature") ||
                           lowerCaseName.Contains("river") || lowerCaseName.Contains("garden") || lowerCaseName.Contains("sanctuary") ||
                           lowerCaseName.Contains("botanical") || lowerCaseName.Contains("trail") || lowerCaseName.Contains("scenic");

                case Mood.Angry:
                    return lowerCaseName.Contains("gym") || lowerCaseName.Contains("boxing") || lowerCaseName.Contains("martial arts") ||
                           lowerCaseName.Contains("fitness") || lowerCaseName.Contains("crossfit") || lowerCaseName.Contains("training") ||
                           lowerCaseName.Contains("climbing") || lowerCaseName.Contains("sports") || lowerCaseName.Contains("athletics") ||
                           lowerCaseName.Contains("exercise") || lowerCaseName.Contains("kickboxing") || lowerCaseName.Contains("weightlifting");

                default:
                    return false;
            }
        }


    }
}
