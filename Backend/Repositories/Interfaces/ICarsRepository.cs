using ProjectRunAway.Models;

namespace ProjectRunAway.Repositories.Interfaces
{
    public interface ICarsRepository : IRepositoryBase<Cars>
    {
        public Cars GetCarWithFeatures(int carId);

    }
}
