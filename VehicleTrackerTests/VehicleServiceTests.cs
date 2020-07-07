using NUnit.Framework;
using System;
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

        [Test]
        public void GetVehicleByGuid()
        {
            var rego = "DEF456";
            var createRequest = new CreateVehicleRequest { registration = rego };
            var vehicle = _vehicleService.CreateVehicle(createRequest).Result;
            var returnedVehicle = _vehicleService.GetVehicle(Guid.Parse(vehicle.guid)).Result;

            Assert.AreEqual(vehicle.guid, returnedVehicle.guid);
        }
    }
}