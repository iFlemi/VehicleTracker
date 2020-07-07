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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [Route("CreateVehicle")]
        [HttpPost]
        public async Task<ActionResult<VehicleModel>> CreateVehicle([FromBody]CreateVehicleRequest body)
        {
            var model = await _vehicleService.CreateVehicle(body);
            return model;
        }

        [Route("GetVehicle")]
        [HttpGet]
        public async Task<ActionResult<VehicleModel>> GetVehicle(Guid guid) {
            var model = await _vehicleService.GetVehicle(guid);
            return model;
        }

        [Route("UpdateVehicle")]
        [HttpPut]
        public async Task<ActionResult<VehicleModel>> UpdateVehicle([FromBody]UpdateVehicleRequest body)
        {
            var model = await _vehicleService.UpdateVehicle(body);
            return model;
        }
        
        [Route("DeleteVehicle")]
        [HttpDelete]
        public async Task<ActionResult> DeleteVehicle(Guid guid)
        {
            bool deleted = await _vehicleService.DeleteVehicle(guid);
            return deleted ? Ok() : StatusCode(500);
        }
    }
}
