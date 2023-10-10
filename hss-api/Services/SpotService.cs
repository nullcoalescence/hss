using hss_api.DAL;
using hss_api.Models;

namespace hss_api.Services
{
    public class SpotService : ISpotService
    {
        private ISpotRepository spotRepository;

        public SpotService(ISpotRepository spotRepository)
        {
            this.spotRepository = spotRepository;
        }

        public List<Spot> GetAllSpots()
        {
            return this.spotRepository
                .GetAllSpots()
                .OrderBy(s => s.Name)
                .ToList();
        }

        public Spot GetSpotById(int id)
        {
            return this.spotRepository.GetSpotById(id);
        }

        public void AddSpot(Spot spot)
        {
            this.spotRepository.InsertSpot(spot);
        }
    }
}
