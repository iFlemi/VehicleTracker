using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.Models;
using VehicleTracker.Models.Request;
using VehicleTracker.Services;

namespace VehicleTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureSensorController : ControllerBase
    {
        private readonly ITemperatureSensorService _sensorService;
        public TemperatureSensorController(ITemperatureSensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [Route("GetTemperatureForVehicle")]
        [HttpGet]
        public async Task<ActionResult<TemperatureSensorModel>> GetTemperatureForVehicle(Guid vehicleGuid) {
            var model = await _sensorService.GetLatestTemperatureForVehicle(vehicleGuid);
            return model;
        }

        [Route("GetTemperaturesForVehicles")]
        [HttpPost]
        public async Task<ActionResult<TemperatureSensorModel[]>> GetTemperaturesForVehicles([FromBody]GetTemperatureForVehiclesRequest body)
        {
            var model = await _sensorService.GetLatestTemperatureForVehicles(body.vehicleGuids);
            return model.ToArray();
        }
    }
}
