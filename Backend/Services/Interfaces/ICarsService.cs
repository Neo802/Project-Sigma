using ProjectRunAway.Models;

namespace ProjectRunAway.Services.Interfaces
{
    public interface ICarsService
    {
        string AddCars(Cars cars);
        void DeleteCars(Cars cars);
        void UpdateCars(Cars cars);
        public Cars GetCarsById(int id);
        public List<Cars> EditExisting();
        IEnumerable<Cars> GetAllCars();
        //public void Save();
    }
}
