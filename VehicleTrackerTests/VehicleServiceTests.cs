using NUnit.Framework;
using VehicleTracker.DataAccess;
using VehicleTracker.Models.Request;
using VehicleTracker.Services;
using VehicleTracker.Services.Impl;

namespace VehicleTrackerTests
{
    public class VehicleServiceTests
    { 
        private IVehicleService _vehicleService;

        [SetUp]
        public void Setup()
        {
             var context = new MockVTContext();
            _vehicleService = new VehicleService(context);
        }

        [Test]
        public void CreateVehicleWithRego()
        {
            var rego = "ABC123";
            var request = new CreateVehicleRequest { registration = rego };
            var vehicle = _vehicleService.CreateVehicle(request).Result;

            Assert.AreEqual(rego, vehicle.registration);
        }
    }
}