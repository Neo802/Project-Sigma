using ProjectRunAway.Models;

namespace ProjectRunAway.Services.Interfaces
{
    public interface ILiabilitiesService
    {
        string AddLiability(Liability liability);
        void DeleteLiability(Liability liability);
        void UpdateLiability(Liability liability);
        public Liability GetLiabilityById(int id);
        public List<Liability> EditExisting();
        IEnumerable<Liability> GetAllLiabilities();
       //public void Save();
    }
}
