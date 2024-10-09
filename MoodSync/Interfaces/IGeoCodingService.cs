using MoodSync.Models;

namespace MoodSync.Interfaces
{
    public interface IGeoCodingService
    {
        Task<LocationData> GetCoordinatesAsync(string locationName);  

    }
}
