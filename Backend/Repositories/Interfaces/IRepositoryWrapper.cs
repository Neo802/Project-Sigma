namespace ProjectRunAway.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ILocationRepository LocationRepository { get; }
        ICarsRepository CarsRepository { get; }
        ILiabilitiesRepository LiabilitiesRepository { get; }
        IFeaturesRepository FeaturesRepository { get; }
        void Save();
    }
}
