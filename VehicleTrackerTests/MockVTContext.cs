using System;
using System.Collections.Generic;
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

        public async Task<VehicleDAO> GetVehicle(string guid)
        {
            return vehicles[guid];
        }
    }
#pragma warning restore CS1998 //Async method lacks 'await' operators and will run synchronously

}
