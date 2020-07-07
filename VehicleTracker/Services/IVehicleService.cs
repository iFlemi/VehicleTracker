using System.Threading.Tasks;
using VehicleTracker.Models;
using VehicleTracker.Models.Request;

namespace VehicleTracker.Services
{
    public interface IVehicleService
    {
        Task<VehicleModel> CreateVehicle(CreateVehicleRequest createVehicleRequest);
    }
}
