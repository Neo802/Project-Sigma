using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Models;

namespace ProjectRunAway.Repositories
{
    public class FeaturesRepository : RepositoryBase<Features>, IFeaturesRepository
    {
        public FeaturesRepository(TableContext featuresContext)
            : base(featuresContext)
        {
        }
    }
}
