using hss_api.Models;

namespace hss_api.Services
{
    public interface ISpotService
    {
        void AddSpot(Spot spot);
        List<Spot> GetAllSpots();
        Spot GetSpotById(int id);
    }
}
