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
        public async Task<VehicleDAO> CreateVehicle(VehicleDAO dao)
        {
            return new VehicleDAO { guid = Guid.NewGuid().ToString(), registration = dao.registration };
        }
    }
#pragma warning restore CS1998 //Async method lacks 'await' operators and will run synchronously

}
