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
        [MaxLength(50)]
        public string make { get; set; }
        [MaxLength(50)]
        public string model { get; set; }
        public int? year { get; set; }

        public VehicleModel ToVehicleModel()
        {
            return new VehicleModel
            {
                registration = this.registration,
                guid = Guid.Parse(this.guid),
                make = this.make,
                model = this.model,
                year = this.year ?? 0
            };
        } 
    }
}
