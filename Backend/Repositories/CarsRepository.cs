using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Models;

namespace ProjectRunAway.Repositories
{
    public class CarsRepository : RepositoryBase<Cars>, ICarsRepository
    {
        public CarsRepository(TableContext carsContext)
            : base(carsContext)
        {
        }
    }
}
