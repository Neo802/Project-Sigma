using ProjectRunAway.Models;
using ProjectRunAway.Repositories;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services.Interfaces;


namespace ProjectRunAway.Services
{
    public class ExtraService : IExtraService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ExtraService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public string AddExtra(Extra extra)
        {
            var addExtra = _repositoryWrapper.CarsRepository.FindByCondition(c => c.CarsId.Equals(extra.CarsId)).FirstOrDefault();
            if (addExtra != null)
            {
                _repositoryWrapper.ExtraRepository.Create(extra);
                _repositoryWrapper.Save();
                return string.Empty;
            }
            return "The extra doesnt exist";

        }

        public void DeleteExtra(Extra extra)
        {
            _repositoryWrapper.ExtraRepository.Delete(extra);
            _repositoryWrapper.Save();
        }
        public void UpdateExtra(Extra extra)
        {
            _repositoryWrapper.ExtraRepository.Update(extra);
            _repositoryWrapper.Save();
        }
        public Extra GetExtraById(int id)
        {
            var extra = _repositoryWrapper.ExtraRepository.FindByCondition(e => e.ExtraId == id).FirstOrDefault();
            if (extra == null)
            {
                return null;
            }
            return extra; // Assuming you want to return the user if found

        }
        public IEnumerable<Extra> GetExtraByCarId(int id)
        {
            return _repositoryWrapper.ExtraRepository.FindByCondition(c => c.CarsId.Equals(id)).ToList();
        }
        public IEnumerable<Extra> GetAllExtras()
        {
            return _repositoryWrapper.ExtraRepository.FindAll().ToList();

        }
        public List<Extra> EditExisting()
        {
            return _repositoryWrapper.ExtraRepository.FindAll().ToList();
        }
    }
}
