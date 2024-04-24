using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;

namespace ProjectRunAway.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TableContext _Context;
        private ILocationRepository? _locationRepository;
        private ICarsRepository? _carsRepository;
        private ILiabilitiesRepository? _liabilitiesRepository;
        private IFeaturesRepository? _featuresRepository;   
        public ILocationRepository LocationRepository
        {
            get
            {
                if (_locationRepository == null)
                {
                    _locationRepository = new LocationRepository(_Context);
                }

                return _locationRepository;
            }
        }

        public ICarsRepository CarsRepository
        {
            get
            {
                if (_carsRepository == null)
                {
                    _carsRepository = new CarsRepository(_Context);
                }

                return _carsRepository;
            }
        }

        public ILiabilitiesRepository LiabilitiesRepository
        {
            get
            {
                if (_liabilitiesRepository == null)
                {
                    _liabilitiesRepository = new LiabilitiesRepository(_Context);
                }

                return _liabilitiesRepository;
            }
        }

        public IFeaturesRepository FeaturesRepository
        {
            get
            {
                if (_featuresRepository == null)
                {
                    _featuresRepository = new FeaturesRepository(_Context);
                }

                return _featuresRepository;
            }
        }

        public RepositoryWrapper(TableContext locationContext)
        {
            _Context = locationContext;
        }

        public void Save()
        {
            _Context.SaveChanges();
        }
    }
}
