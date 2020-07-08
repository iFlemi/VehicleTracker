using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.DataAccess;
using VehicleTracker.DataAccess.DAO;
using VehicleTracker.Models;
using VehicleTracker.Models.Request;

namespace VehicleTracker.Services.Impl
{
    public class TemperatureSensorService : ITemperatureSensorService
    {
        private readonly IVTContext _context;

        public TemperatureSensorService(IVTContext context)
        {
            _context = context;
        }

        public async Task<TemperatureSensorModel> GetLatestTemperatureForVehicle(Guid vehicleGuid)
        {
            var dao = await _context.GetLatestTemperatureForVehicle(vehicleGuid.ToString());
            return dao.ToSensorModel();
        }
    }
}
