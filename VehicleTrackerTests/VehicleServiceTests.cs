using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleTracker.Models;
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
            var vehicle = CreateVehicleForMockDB(rego);
            Assert.AreEqual(rego, vehicle.registration);
        }

        [Test]
        public void GetVehicleByGuid()
        {
            var rego = "DEF456";
            var vehicle = CreateVehicleForMockDB(rego);
            var createdVehicle = RetriveVehicleFromMockDB(vehicle.guid);

            Assert.AreEqual(vehicle.guid, createdVehicle.guid);
        }

        [Test]
        public void GetAllVehicles()
        {
            var regos = new HashSet<string> { "ABC123", "DEF456" };
            foreach (var rego in regos)
                CreateVehicleForMockDB(rego);
            var vehicles = _vehicleService.GetAllVehicles().Result;

            Assert.IsTrue(
                regos.Count() == vehicles.Count() 
                && vehicles.All(v => regos.Contains(v.registration)
                ));
        }

        [Test]
        public void UpdateVehicleRegistration()
        {
            var rego = "GHI789";
            var vehicle = CreateVehicleForMockDB(rego);
            var createdVehicle = RetriveVehicleFromMockDB(vehicle.guid);

            var updatedRego = "JKL012";
            var updateVehicleRequest = new UpdateVehicleRequest { guid = createdVehicle.guid, registration = updatedRego };
            var updatedVehicle = _vehicleService.UpdateVehicle(updateVehicleRequest).Result;

            Assert.AreEqual(updatedRego, updatedVehicle.registration);
        }

        [Test]
        public void DeleteVehicle()
        {
            var rego = "MNO345";
            var vehicle = CreateVehicleForMockDB(rego);
            var createdVehicle = RetriveVehicleFromMockDB(vehicle.guid);

            var successfullyDeleted = _vehicleService.DeleteVehicle(createdVehicle.guid).Result;
            Assert.IsTrue(successfullyDeleted);
        }

        private VehicleModel CreateVehicleForMockDB(string rego)
        {
            var request = new CreateVehicleRequest { registration = rego };
            var vehicle = _vehicleService.CreateVehicle(request).Result;
            return vehicle;
        }

        private VehicleModel RetriveVehicleFromMockDB(Guid guid)
        {
            return _vehicleService.GetVehicle(guid).Result;
        }
    }
}