using MoodSync.Models;

public interface ILocationService
{
    Task<LocationData> GetCoordinatesAsync(string location);
    Task<NearbyPlacesData> GetNearbyPlacesAsync(double latitude, double longitude);
}
