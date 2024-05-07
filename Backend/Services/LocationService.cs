using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services.Interfaces;


namespace ProjectRunAway.Services
{
    public class LocationService : ILocationService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LocationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void AddLocation(Locations location)
        {
            _repositoryWrapper.LocationRepository.Create(location);

        }

        public void DeleteLocation(Locations location)
        {
            _repositoryWrapper.LocationRepository.Delete(location);
        }
        public void UpdateLocation(Locations location)
        {
            _repositoryWrapper.LocationRepository.Update(location);
        }
        public void Save()
        {
            _repositoryWrapper.Save();
        }
        public Locations GetLocationById(int id)
        {
            var location = _repositoryWrapper.LocationRepository.FindByCondition(location => location.LocationsId == id).FirstOrDefault();
            if (location == null)
            {
                return null;
            }
            return location; // Assuming you want to return the user if found

        }
        public IEnumerable<Locations> GetAllLocations()
        {
            return _repositoryWrapper.LocationRepository.FindAll().ToList();

        }
        public List<Locations> EditExisting()
        {
            return _repositoryWrapper.LocationRepository.FindAll().ToList();
        }
       

    }
}
