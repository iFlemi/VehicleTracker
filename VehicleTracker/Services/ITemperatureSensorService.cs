using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracker.Models;
using VehicleTracker.Models.Request;

namespace VehicleTracker.Services
{
    public interface ITemperatureSensorService
    {
        Task<TemperatureSensorModel> GetLatestTemperatureForVehicle(Guid vehicleGuid);
        Task<IEnumerable<TemperatureSensorModel>> GetLatestTemperatureForVehicles(IEnumerable<Guid> vehicleGuid);

    }
}
