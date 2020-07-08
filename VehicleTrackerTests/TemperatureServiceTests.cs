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
    public class TemperatureServiceTests
    { 
        private ITemperatureSensorService _temperatureSensorService;

        [SetUp]
        public void Setup()
        {
             var context = new MockVTContext();
            _temperatureSensorService = new TemperatureSensorService(context);
        }

        [Test]
        public void RetrieveTemperatureForGuid()
        {
            var guid = Guid.NewGuid();
            var temperatureSensor = _temperatureSensorService.GetLatestTemperatureForVehicle(guid).Result;
            Assert.IsTrue(temperatureSensor.temperatureC > 0);
        }
    }
}