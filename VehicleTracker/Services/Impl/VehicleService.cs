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
    public class VehicleService : IVehicleService
    {
        private readonly IVTContext _context;

        public VehicleService(IVTContext context)
        {
            _context = context;
        }

        public async Task<VehicleModel> CreateVehicle(CreateVehicleRequest createVehicleRequest)
        {
            var dao = new VehicleDAO {
                registration = createVehicleRequest.registration,
                guid = Guid.NewGuid().ToString()
            };

            await _context.CreateVehicle(dao);
            return dao.ToVehicleModel();
        }

        public async Task<bool> DeleteVehicle(Guid guid)
        {
            bool success = await _context.DeleteVehicle(guid);
            return success;
        }

        public async Task<VehicleModel> GetVehicle(Guid guid)
        {
            var dao = await _context.GetVehicle(guid.ToString());
            return dao.ToVehicleModel();
        }

        public async Task<IEnumerable<VehicleModel>> GetAllVehicles()
        {
            var daos = await _context.GetAllVehicles();
            return daos.Select(d => d.ToVehicleModel());
        }


        public async Task<VehicleModel> UpdateVehicle(UpdateVehicleRequest updateVehicleRequest)
        {
            var dao = await _context.GetVehicle(updateVehicleRequest.guid.ToString());
            dao.registration = updateVehicleRequest.registration;

            var updatedDao = await _context.UpdateVehicle(dao);
            return updatedDao.ToVehicleModel();
        }
    }
}
