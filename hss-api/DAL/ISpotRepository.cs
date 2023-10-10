using hss_api.Models;

namespace hss_api.DAL
{
    public interface ISpotRepository : IDisposable
    {
        IEnumerable<Spot> GetAllSpots();
        Spot GetSpotById(int id);
        void InsertSpot(Spot spot);
        void DeleteSpot(int id);
        void UpdateSpot(Spot spot);
        void Save();
    }
}
