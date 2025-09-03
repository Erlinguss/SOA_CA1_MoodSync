using MoodSync.Models;

public interface ILocationService
{
    Task<NearbyPlacesData> GetNearbyPlacesAsync(double latitude, double longitude);
}
