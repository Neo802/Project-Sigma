using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services.Interfaces;


namespace ProjectRunAway.Services
{
    public class CarsService : ICarsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CarsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public string AddCars(Cars cars)
        {
            var addCars = _repositoryWrapper.CarsRepository.FindByCondition(c => c.UsersId.Equals(cars.UsersId)).FirstOrDefault();
            if(addCars != null)
            {
                _repositoryWrapper.CarsRepository.Create(cars);
                _repositoryWrapper.Save();
                return string.Empty;
            }
            return "The car doesnt exist";
        }

        public void DeleteCars(Cars cars)
        {
            _repositoryWrapper.CarsRepository.Delete(cars);
            _repositoryWrapper.Save();
        }
        public void UpdateCars(Cars cars)
        {
            _repositoryWrapper.CarsRepository.Update(cars);
            _repositoryWrapper.Save();
        }
        /*
        public void Save()
        {
            _repositoryWrapper.Save();
        }
        */
        public Cars GetCarsById(int id)
        {
            var cars = _repositoryWrapper.CarsRepository.FindByCondition(cars => cars.CarsId == id).FirstOrDefault();
            if (cars == null)
            {
                return null;
            }
            return cars; // Assuming you want to return the user if found

        }
        public IEnumerable<Cars> GetAllCars()
        {
            return _repositoryWrapper.CarsRepository.FindAll().ToList();

        }
        public List<Cars> EditExisting()
        {
            return _repositoryWrapper.CarsRepository.FindAll().ToList();
        }
    }
}
