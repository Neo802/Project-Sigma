
using Moq;
using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services;

namespace ProjectRunAwayTest
{
    [TestClass]
    public class LocationTest
    {
        private Mock<IRepositoryWrapper> _mockWrapper;
        private List<Locations> _locations;
        private LocationService _locationService;

        [TestInitialize]
        public void Setup()
        {
            _mockWrapper = new Mock<IRepositoryWrapper>();
            _locationService = new LocationService(_mockWrapper.Object);
            _locations = new List<Locations>
            {
                new Locations
                {
                    LocationsId = 1,
                    City = "Craiova",
                    CarsAvailable = 1,
                    Description = "da",
                    Image = "https://xplorer.ro/wp-content/uploads/2023/10/TOP-23-obiective-turistice-Craiova-768x514.webp"
                },
                new Locations
                {
                    LocationsId = 2,
                    City = "Bucuresti",
                    CarsAvailable = 2,
                    Description = "yes",
                    Image = "https://s.inyourpocket.com/gallery/bucharest/2020/02/256716.jpg"
                }
            };
        }
        [TestMethod]
        public void GetLocationById_ReturnsCorrectLocation()
        {
            _mockWrapper.Setup(x => x.LocationRepository.GetLocationById(1)).Returns(_locations[0]);
            var result = _locationService.GetLocationById(1);
            Assert.AreEqual("Craiova", result.City);
            Assert.AreEqual(1, result.CarsAvailable);
            Assert.AreEqual("https://xplorer.ro/wp-content/uploads/2023/10/TOP-23-obiective-turistice-Craiova-768x514.webp", result.Image);
            Assert.AreEqual("da", result.Description);
        }
        [TestMethod]
        public void GetAllLocations_ReturnsCorrectLocations()
        {
            _mockWrapper.Setup(x => x.LocationRepository.FindAll()).Returns(_locations.AsQueryable());
            var result = _locationService.GetAllLocations().ToList();
            Assert.AreEqual(_locations, result);
        }

    }
}
