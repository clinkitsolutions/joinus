using Fleet.Vehicles.Models;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Repositories
{
    public interface IVehicleLogItemRepository
    {
        Task CreateAsync(VehicleLogItem item);
    }
}
