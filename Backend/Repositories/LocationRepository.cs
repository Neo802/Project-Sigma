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
    }
}
