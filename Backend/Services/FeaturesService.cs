using ProjectRunAway.Models;
using ProjectRunAway.Repositories;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services.Interfaces;


namespace ProjectRunAway.Services
{
    public class FeaturesService : IFeaturesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FeaturesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public string AddFeature(Features feature)
        {
            var addLiability = _repositoryWrapper.CarsRepository.FindByCondition(c => c.CarsId.Equals(feature.CarsId)).FirstOrDefault();
            if (addLiability != null)
            {
                _repositoryWrapper.FeaturesRepository.Create(feature);
                _repositoryWrapper.Save();
                return string.Empty;
            }
            return "The car doesnt exist";

        }

        public void DeleteFeature(Features feature)
        {
            _repositoryWrapper.FeaturesRepository.Delete(feature);
            _repositoryWrapper.Save();
        }
        public void UpdateFeature(Features feature)
        {
            _repositoryWrapper.FeaturesRepository.Update(feature);
            _repositoryWrapper.Save();
        }
        /*
        public void Save()
        {
            _repositoryWrapper.Save();
        }
        */
        public Features GetFeatureById(int id)
        {
            var feature = _repositoryWrapper.FeaturesRepository.FindByCondition(liability => liability.FeaturesId == id).FirstOrDefault();
            if (feature == null)
            {
                return null;
            }
            return feature; // Assuming you want to return the user if found

        }
        public IEnumerable<Features> GetAllFeatures()
        {
            return _repositoryWrapper.FeaturesRepository.FindAll().ToList();

        }
        public List<Features> EditExisting()
        {
            return _repositoryWrapper.FeaturesRepository.FindAll().ToList();
        }
    }
}
