using ProjectRunAway.Models;

namespace ProjectRunAway.Services.Interfaces
{
    public interface ILocationService
    {
        void AddLocation(Locations location);
        void DeleteLocation(Locations location);
        void UpdateLocation(Locations location);
        public Locations GetLocationById(int id);
        public List<Locations> EditExisting();
        IEnumerable<Locations> GetAllLocations();
        public void Save();
    }
}
