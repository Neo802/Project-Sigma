using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectRunAway.Repositories
{
    public class CarsRepository : RepositoryBase<Cars>, ICarsRepository
    {
        private readonly TableContext _context;

        public CarsRepository(TableContext carsContext)
            : base(carsContext)
        {
            _context = carsContext;
        }
        public Cars GetCarWithFeatures(int carId)
        {
            // Include Features in the query
            return _context.Cars
                           .Include(c => c.Features)
                           .FirstOrDefault(c => c.CarsId == carId);
        }
    }
}
