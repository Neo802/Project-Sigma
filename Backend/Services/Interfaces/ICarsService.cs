using ProjectRunAway.Models;

namespace ProjectRunAway.Services.Interfaces
{
    public interface ICarsService
    {
        string AddCars(Cars cars);
        void DeleteCars(Cars cars);
        void UpdateCars(Cars cars);
        public Cars GetCarsById(int id);
        public Cars GetCarWithFeatures(int carId);
        public List<Cars> EditExisting();
        IEnumerable<Cars> GetAllCars();
        IEnumerable<Cars> GetCarsByAvailabilityLocation(int locationId);
        //public void Save();
    }
}
