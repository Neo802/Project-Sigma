using ProjectRunAway.Models;
namespace ProjectRunAway.Repositories.Interfaces
{
    public interface ILocationRepository : IRepositoryBase<Locations>
    {
        Locations GetLocationById(int id);
    }
   
}
