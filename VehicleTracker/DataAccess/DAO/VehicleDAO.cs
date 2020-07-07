using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.Models;

namespace VehicleTracker.DataAccess.DAO
{
    public class VehicleDAO
    {
        [Required]
        [Key]
        public string guid { get; set; }

        [MaxLength(10)]
        public string registration { get; set; }

        public VehicleModel ToVehicleModel()
        {
            return new VehicleModel
            {
                registration = this.registration,
                guid = this.guid.ToString()
            };
        } 
    }
}
