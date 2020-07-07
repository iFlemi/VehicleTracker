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
            var returnedVehicle = _vehicleService.GetVehicle(vehicle.guid).Result;

            Assert.AreEqual(vehicle.guid, returnedVehicle.guid);
        }

        [Test]
        public void UpdateVehicleRegistration()
        {
            var rego = "GHI789";
            var createRequest = new CreateVehicleRequest { registration = rego };
            var vehicleToCreate = _vehicleService.CreateVehicle(createRequest).Result;
            var createdVehicle = _vehicleService.GetVehicle(vehicleToCreate.guid).Result;

            var updatedRego = "JKL012";
            var updateVehicleRequest = new UpdateVehicleRequest { guid = createdVehicle.guid, registration = updatedRego };
            var updatedVehicle = _vehicleService.UpdateVehicle(updateVehicleRequest).Result;

            Assert.AreEqual(updatedRego, updatedVehicle.registration);
        }

        [Test]
        public void DeleteVehicle()
        {
            var rego = "MNO345";
            var createRequest = new CreateVehicleRequest { registration = rego };
            var vehicleToCreate = _vehicleService.CreateVehicle(createRequest).Result;
            var createdVehicle = _vehicleService.GetVehicle(vehicleToCreate.guid).Result;

            var successfullyDeleted = _vehicleService.DeleteVehicle(createdVehicle.guid).Result;
            Assert.IsTrue(successfullyDeleted);
        }
    }
}