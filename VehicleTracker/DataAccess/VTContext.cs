using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleTracker.DataAccess.DAO;

namespace VehicleTracker.DataAccess
{
    public class VTContext : DbContext, IVTContext
    {
        public VTContext(DbContextOptions<VTContext> options) : base(options)
        {
        }

        public DbSet<VehicleDAO> Vehicles { get; set; }

        public async Task<VehicleDAO> CreateVehicle(VehicleDAO dao)
        {
            Vehicles.Add(dao);
            await SaveChangesAsync();
            return dao;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDAO>().ToTable("Vehicles");
        }
    }
}
