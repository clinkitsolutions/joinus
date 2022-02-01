using Fleet.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Repositories
{
    public interface IVehicleRepository
    {
        Task CreateAsync(Vehicle vehicle);
        Task<Vehicle> GetAsync(int id);
        Task<Vehicle> GetAsync(string name, VehicleType type);
        Task<IEnumerable<Vehicle>> GetAsync();
        Task<IEnumerable<Vehicle>> GetAsync(Expression<Func<Vehicle,bool>> filter);
    }
}
