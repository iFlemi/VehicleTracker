using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracker.DataAccess.DAO;

namespace VehicleTracker.DataAccess
{
    public interface IVTContext
    {
        public Task<VehicleDAO> CreateVehicle(VehicleDAO dao);
        public Task<VehicleDAO> GetVehicle(string guid);
        public Task<IEnumerable<VehicleDAO>> GetAllVehicles();
        public Task<VehicleDAO> UpdateVehicle(VehicleDAO dao);
        public Task<bool> DeleteVehicle(Guid guid);
    }
}
