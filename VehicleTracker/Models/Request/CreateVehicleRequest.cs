﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models.Request
{
    public class CreateVehicleRequest
    {
        public string registration { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
    }
}
