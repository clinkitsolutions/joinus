using Fleet.Vehicles.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Repositories
{
    public class EfCoreVehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _database;

        public EfCoreVehicleRepository(VehicleDbContext database)
        {
            _database = database;
        }

        public async Task CreateAsync(Vehicle vehicle)
        {
            _database.Vehicles.Add(vehicle);
            await _database.SaveChangesAsync();
        }

        public async Task<Vehicle> GetAsync(int id)
        {
            return await _database.Vehicles
                .Where(v => v.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAsync()
        {
            return await _database.Vehicles
                .Where(v => v.Log.Any())
                .Include(v => v.Log.OrderBy(l => l.Location.Timestamp))
                .ToListAsync();
        }


        public async Task<IEnumerable<Vehicle>> GetAsync(Expression<Func<Vehicle, bool>> filter)
        {
            return await _database.Vehicles
                .Where(filter)
                .Where(v => v.Log.Any())
                .Include(v => v.Log.OrderBy(l => l.Location.Timestamp))
                .ToListAsync();
        }
    }
}
