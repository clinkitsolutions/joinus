using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Repositories
{
    public class EfCoreFleetRepository : IFleetRepository
    {
        private readonly VehicleDbContext _database;

        public EfCoreFleetRepository(VehicleDbContext database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Models.Fleet>> GetAsync()
        {
            return await _database.Fleets.ToListAsync();
        }
    }
}
