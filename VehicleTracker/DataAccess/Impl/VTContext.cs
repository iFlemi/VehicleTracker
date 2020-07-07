using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleTracker.DataAccess.DAO;

namespace VehicleTracker.DataAccess.Impl
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

        public async Task<VehicleDAO> GetVehicle(string guid)
        {
            var vehicle = await Vehicles.FirstOrDefaultAsync(v => v.guid == guid);
            return vehicle;
        }

        public async Task<VehicleDAO> UpdateVehicle(VehicleDAO dao)
        {
            Vehicles.Update(dao);
            await SaveChangesAsync();
            return dao;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDAO>().ToTable("Vehicles");
        }
    }
}
