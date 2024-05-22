using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace ProjectRunAway.Services
{
    public class CarsService : ICarsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public IEnumerable<Cars> GetCarsByAvailabilityLocation(int locationId)
        {
            IQueryable<Availability> filteredAvailabilities = _repositoryWrapper.AvailabilityRepository
            .FindByCondition(a => a.LocationsId == locationId);
            // Now, fetch the cars based on the availabilities. This presumes that the Availability entity
            // has a navigation property 'Car' that can be used to directly access related car data.
            IEnumerable<Cars> cars = filteredAvailabilities
                .Select(a => a.Cars)
                .Distinct()  // Remove duplicates if a car is linked to multiple availabilities
                .ToList();   // Execute the query and convert the results to a list

            return cars;
        }

        public CarsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public string AddCars(Cars cars)
        {
            var addCars = _repositoryWrapper.CarsRepository;
            if (addCars != null)
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
<<<<<<< Updated upstream
            var cars = _repositoryWrapper.CarsRepository.FindByCondition(cars => cars.CarsId == id).FirstOrDefault();
            if (cars == null)
=======
            var car = _repositoryWrapper.CarsRepository
                .FindByCondition(c => c.CarsId == id)
                .FirstOrDefault();

            if (car == null)
>>>>>>> Stashed changes
            {
                return null;
            }
            return cars; // Assuming you want to return the user if found

<<<<<<< Updated upstream
=======
            car.Features = _repositoryWrapper.FeaturesRepository
                .FindByCondition(f => f.CarsId == id)
                .ToList();

            return car;
>>>>>>> Stashed changes
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
