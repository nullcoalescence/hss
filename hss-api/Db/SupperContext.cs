using hss_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hss_api.Db
{
    public class SupperContext : DbContext
    {
        private readonly string dbName = "supper.db";

        public DbSet<User> Users { get; set; }

        public string DbPath { get; }

        public SupperContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = Path.Join(path, dbName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
