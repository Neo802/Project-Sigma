
using ProjectRunAway.Models;

namespace ProjectRunAway.Services.Interfaces
{
    public interface IExtraService
    {
        string AddExtra(Extra extra);
        void DeleteExtra(Extra extra);
        void UpdateExtra(Extra extra);
        public Extra GetExtraById(int id);
        public IEnumerable<Extra> GetExtraByCarId(int id);
        public List<Extra> EditExisting();
        IEnumerable<Extra> GetAllExtras();

    }
}
