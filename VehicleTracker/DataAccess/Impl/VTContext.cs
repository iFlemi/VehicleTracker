using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public DbSet<TemperatureSensorDAO> TemperatureSensors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleDAO>().ToTable("Vehicles");
            modelBuilder.Entity<TemperatureSensorDAO>().ToTable("TemperatureSensors");
        }

        public async Task<VehicleDAO> CreateVehicle(VehicleDAO dao)
        {
            Vehicles.Add(dao);
            await SaveChangesAsync();
            return dao;
        }

        public async Task<bool> DeleteVehicle(Guid guid)
        {
            try
            {
                var vehicleToDelete = await Vehicles.FirstOrDefaultAsync(v => v.guid == guid.ToString());
                Vehicles.Remove(vehicleToDelete);
                await SaveChangesAsync();
                return true;
            }  catch {
                return false;
            }
        }

        public async Task<VehicleDAO> GetVehicle(string guid)
        {
            var vehicle = await Vehicles.FirstOrDefaultAsync(v => v.guid == guid);
            return vehicle;
        }

        public async Task<IEnumerable<VehicleDAO>> GetAllVehicles()
        {
            var vehicles = await Vehicles.ToListAsync();//Assumption: paging not required.
            return vehicles;
        }

        public async Task<VehicleDAO> UpdateVehicle(VehicleDAO daoToUpdate)
        {
            Vehicles.Update(daoToUpdate);
            await SaveChangesAsync();
            var updatedDao = await Vehicles.FirstOrDefaultAsync(v => v.guid == daoToUpdate.guid);
            return updatedDao;
        }

        public async Task<TemperatureSensorDAO> GetLatestTemperatureForVehicle(string guid)
        {
            var dao = await TemperatureSensors
                .Where(s => s.vehicleGuid == guid)
                .OrderByDescending(s => s.observedAt)
                .FirstOrDefaultAsync();
            return dao;
        }
    }
}
