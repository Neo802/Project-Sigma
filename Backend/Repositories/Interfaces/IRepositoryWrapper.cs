namespace ProjectRunAway.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAvailabilityRepository AvailabilityRepository { get; }
        ILocationRepository LocationRepository { get; }
        ICarsRepository CarsRepository { get; }
        ILiabilitiesRepository LiabilitiesRepository { get; }
        IFeaturesRepository FeaturesRepository { get; }
        IExtraRepository ExtraRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        void Save();
    }
}
