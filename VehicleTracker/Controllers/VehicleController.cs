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
    }
}
