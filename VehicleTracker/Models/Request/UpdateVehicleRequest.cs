﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracker.Models.Request
{
    public class UpdateVehicleRequest
    {
        public Guid guid { get; set; }
        public string registration { get; set; }
    }
}
