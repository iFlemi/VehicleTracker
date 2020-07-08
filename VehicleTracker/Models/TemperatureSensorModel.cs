using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class TemperatureSensorModel
    { 
        public Guid vehicleGuid { get; set; }
        public DateTime observedAt { get; set; }
        public decimal temperatureC { get; set; }

    }
}
