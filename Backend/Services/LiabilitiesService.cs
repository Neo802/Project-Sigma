using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services.Interfaces;


namespace ProjectRunAway.Services
{
    public class LiabilitiesService : ILiabilitiesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LiabilitiesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public string AddLiability(Liability liability)
        {
            var addLiability = _repositoryWrapper.CarsRepository.FindByCondition(c => c.CarsId.Equals(liability.CarsId)).FirstOrDefault();
            if (addLiability != null)
            {
                _repositoryWrapper.LiabilitiesRepository.Create(liability);
                _repositoryWrapper.Save();
                return string.Empty;
            }
            return "The car doesnt exist";

        }

        public void DeleteLiability(Liability liability)
        {
            _repositoryWrapper.LiabilitiesRepository.Delete(liability);
            _repositoryWrapper.Save();
        }
        public void UpdateLiability(Liability liability)
        {
            _repositoryWrapper.LiabilitiesRepository.Update(liability);
            _repositoryWrapper.Save();
        }
 
        public Liability GetLiabilityById(int id)
        {
            var liability = _repositoryWrapper.LiabilitiesRepository.FindByCondition(liability => liability.LiabilityId == id).FirstOrDefault();
            if (liability == null)
            {
                return null;
            }
            return liability; // Assuming you want to return the user if found

        }
        public IEnumerable<Liability> GetLiabilityByCarId(int id)
        {
            return _repositoryWrapper.LiabilitiesRepository.FindByCondition(c => c.CarsId.Equals(id)).ToList();
        }

        public IEnumerable<Liability> GetAllLiabilities()
        {
            return _repositoryWrapper.LiabilitiesRepository.FindAll().ToList();

        }
        public List<Liability> EditExisting()
        {
            return _repositoryWrapper.LiabilitiesRepository.FindAll().ToList();
        }
    }
}
