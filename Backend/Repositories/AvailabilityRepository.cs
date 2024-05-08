using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Models;

namespace ProjectRunAway.Repositories
{
    public class AvailabilityRepository : RepositoryBase<Availability>, IAvailabilityRepository
    {
        public AvailabilityRepository(TableContext availabilityContext)
            : base(availabilityContext)
        {
        }
    }
}
