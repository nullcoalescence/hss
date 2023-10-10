using hss_api.Db;
using hss_api.Models;

using Microsoft.EntityFrameworkCore;

namespace hss_api.DAL
{
    public class SpotRepository : ISpotRepository, IDisposable
    {
        private SupperContext supperContext;
        private bool disposed = false;

        public SpotRepository(SupperContext supperContext)
        {
            this.supperContext = supperContext;
        }

        public IEnumerable<Spot> GetAllSpots()
        {
            return this.supperContext.Spots.ToList();
        }

        public Spot GetSpotById(int id)
        {
            return this.supperContext.Spots.Find(id);
        }

        public void InsertSpot(Spot spot)
        {
            this.supperContext.Spots.Add(spot);

            Save();
        }

        public void DeleteSpot(int spotId)
        {
            Spot spot = this.supperContext.Spots.Find(spotId);
            this.supperContext.Spots.Remove(spot);

            Save();
        }

        public void UpdateSpot(Spot spot)
        {
            this.supperContext.Entry(spot).State = EntityState.Modified;

            Save();
        }

        public void Save()
        {
            this.supperContext.SaveChanges();
        }

        // Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.supperContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
