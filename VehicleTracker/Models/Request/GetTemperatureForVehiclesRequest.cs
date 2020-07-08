using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models.Request
{
    public class GetTemperatureForVehiclesRequest
    {
        public Guid[] vehicleGuids { get; set; }
    }
}
