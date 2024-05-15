using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Models;

namespace ProjectRunAway.Repositories
{
    public class LocationRepository : RepositoryBase<Locations>, ILocationRepository
    {
        public LocationRepository(TableContext locationContext)
            : base(locationContext)
        {
        }
        public Locations GetLocationById(int id)
        {
            return FindByCondition(location => location.LocationsId == id).FirstOrDefault();
        }
    }
}
