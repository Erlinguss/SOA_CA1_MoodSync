using MoodSync.Enums;
using MoodSync.Interfaces;
using MoodSync.Models;
using System.Linq;

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
        private static readonly Dictionary<Mood, List<string>> moodPlaceTypes = new Dictionary<Mood, List<string>>
{
    {
        Mood.Happy, new List<string>
        {
            "amusement_park", "cafe", "restaurant", "bar", "night_club", "park",
            "zoo", "aquarium", "movie_theater", "bowling_alley", "casino",
            "tourist_attraction", "shopping_mall", "establishment"
        }
    },
    {
        Mood.Sad, new List<string>
        {
            "library", "art_gallery", "museum", "church", "book_store", "theater",
            "cathedral", "planetarium", "point_of_interest"
        }
    },
    {
        Mood.Stressed, new List<string>
        {
            "spa", "yoga_studio", "gym", "nature_reserve", "lake", "botanical_garden",
            "national_park", "hiking_area", "wellness_center", "lodging"
        }
    },
    {
        Mood.Relaxed, new List<string>
        {
            "park", "beach", "lake", "river", "botanical_garden", "vineyard",
            "national_park", "resort", "scenic_viewpoint", "tourist_attraction", "point_of_interest"
        }
    },
    {
        Mood.Angry, new List<string>
        {
            "gym", "boxing_gym", "martial_arts_school", "stadium", "rock_climbing_gym",
            "sports_complex", "kickboxing", "crossfit", "running_track", "lodging"
        }
    }
};

        private bool IsPlaceSuitableForMood(NearbyPlacesData.Place place, Mood mood)
        {
            if (moodPlaceTypes.TryGetValue(mood, out var types))
            {
                foreach (var type in place.Types)
                {
                    if (types.Contains(type.ToLower()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
