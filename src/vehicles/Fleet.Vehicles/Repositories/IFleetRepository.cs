using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleet.Vehicles.Repositories
{
    public interface IFleetRepository
    {
        Task<IEnumerable<Models.Fleet>> GetAsync();
    }
}
