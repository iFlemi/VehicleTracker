using System.Threading.Tasks;
using VehicleTracker.DataAccess.DAO;

namespace VehicleTracker.DataAccess
{
    public interface IVTContext
    {
        public Task<VehicleDAO> CreateVehicle(VehicleDAO dao);
        public Task<VehicleDAO> GetVehicle(string guid);
    }
}
