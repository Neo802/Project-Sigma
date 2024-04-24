using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Models;

namespace ProjectRunAway.Repositories
{
    public class LiabilitiesRepository : RepositoryBase<Liability>, ILiabilitiesRepository
    {
        public LiabilitiesRepository(TableContext liabilitiesContext)
            : base(liabilitiesContext)
        {
        }
    }
}
