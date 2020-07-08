using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.Models;

namespace VehicleTracker.DataAccess.DAO
{
    public class TemperatureSensorDAO
    {
        [Required]
        [Key]
        public string vehicleGuid { get; set; }
        public DateTime observedAt { get; set; }

        public decimal? temperatureC { get; set; }

        public TemperatureSensorModel ToSensorModel()
        {
            return new TemperatureSensorModel
            {
                vehicleGuid = Guid.Parse(this.vehicleGuid),
                observedAt = this.observedAt,
                temperatureC = this.temperatureC ?? 0
            };
        } 
    }
}
