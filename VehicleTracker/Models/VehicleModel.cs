using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models
{
    public class VehicleModel
    {
        public string registration { get; set; }
        public Guid guid { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
    }
}
