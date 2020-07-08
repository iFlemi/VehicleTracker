using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracker.DataAccess;
using VehicleTracker.DataAccess.DAO;

namespace VehicleTrackerTests
{
#pragma warning disable CS1998 //Async method lacks 'await' operators and will run synchronously
    public class MockVTContext : IVTContext
    {
        Dictionary<string, VehicleDAO> vehicles = new Dictionary<string, VehicleDAO> { };

        public async Task<VehicleDAO> CreateVehicle(VehicleDAO dao)
        {            
            vehicles.Add(dao.guid, dao);
            return dao;
        }

        public async Task<bool> DeleteVehicle(Guid guid)
        {
            try
            {
                vehicles.Remove(guid.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<VehicleDAO> GetVehicle(string guid)
        {
            return vehicles[guid];
        }

        public async Task<IEnumerable<VehicleDAO>> GetAllVehicles()
        {
            return vehicles.Select(v => v.Value);
        }

        public async Task<VehicleDAO> UpdateVehicle(VehicleDAO daoForUpdate)
        {
            var vehicle = vehicles[daoForUpdate.guid];
            vehicle.registration = daoForUpdate.registration;
            vehicles[daoForUpdate.guid] = vehicle;
            return vehicle;
        }

        public async Task<TemperatureSensorDAO> GetLatestTemperatureForVehicle(string guid)
        {
            return new TemperatureSensorDAO { vehicleGuid = guid, observedAt = DateTime.Now, temperatureC = 10.00m };
        }

        public async Task<IEnumerable<TemperatureSensorDAO>> GetLatestTemperaturesForVehicles(IEnumerable<string> guids)
        {
            var temps = new List<TemperatureSensorDAO>();
            foreach (var guid in guids)
                temps.Add(new TemperatureSensorDAO { vehicleGuid = guid, observedAt = DateTime.Now, temperatureC = 10.00m });

            return temps;
        }
    }
#pragma warning restore CS1998 //Async method lacks 'await' operators and will run synchronously

}
