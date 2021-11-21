using Fleet.Vehicles.Models;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Repositories
{
    public class EfCoreVehicleLogItemRepository : IVehicleLogItemRepository
    {
        private readonly VehicleDbContext _database;

        public EfCoreVehicleLogItemRepository(VehicleDbContext database)
        {
            _database = database;
        }

        public async Task CreateAsync(VehicleLogItem item)
        {
            _database.VehicleLogItems.Add(item);
            _database.Vehicles.Attach(item.Vehicle);
            await _database.SaveChangesAsync();
        }
    }
}
