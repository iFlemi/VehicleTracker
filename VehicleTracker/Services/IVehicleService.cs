using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracker.Models;
using VehicleTracker.Models.Request;

namespace VehicleTracker.Services
{
    public interface IVehicleService
    {
        Task<VehicleModel> CreateVehicle(CreateVehicleRequest createVehicleRequest);
        Task<VehicleModel> GetVehicle(Guid guid);
        Task<VehicleModel> UpdateVehicle(UpdateVehicleRequest updateVehicleRequest);
        Task<bool> DeleteVehicle(Guid guid);
        Task<IEnumerable<VehicleModel>> GetAllVehicles();
    }
}
