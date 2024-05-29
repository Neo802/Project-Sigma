using Moq;
using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectRunAwayTest
{
    [TestClass]
    public class LocationTest
    {
        private Mock<IRepositoryWrapper> _mockWrapper;
        private Mock<ILocationRepository> _mockLocationRepository;
        private List<Locations> _locations;
        private LocationService _locationService;


        [TestInitialize]
        public void Setup()
        {
            _mockWrapper = new Mock<IRepositoryWrapper>();
            _mockLocationRepository = new Mock<ILocationRepository>();
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

            _mockWrapper.Setup(x => x.LocationRepository).Returns(_mockLocationRepository.Object);
        }


        [TestMethod]
        public void GetLocationById_ReturnsCorrectLocation()
        {
            // Arrange
            _mockWrapper.Setup(x => x.LocationRepository.GetLocationById(1)).Returns(_locations[0]);

            // Act
            var result = _locationService.GetLocationById(1);

            // Assert
            Assert.AreEqual("Craiova", result.City);
            Assert.AreEqual(1, result.CarsAvailable);
            Assert.AreEqual("https://xplorer.ro/wp-content/uploads/2023/10/TOP-23-obiective-turistice-Craiova-768x514.webp", result.Image);
            Assert.AreEqual("da", result.Description);
        }


        [TestMethod]
        public void GetAllLocations_ReturnsCorrectLocations()
        {
            // Arrange
            _mockWrapper.Setup(x => x.LocationRepository.FindAll()).Returns(_locations.AsQueryable());

            // Act
            var result = _locationService.GetAllLocations();

            // Assert
            Assert.AreEqual(_locations.Count, result.Count);
            for (int i = 0; i < _locations.Count; i++)
            {
                Assert.AreEqual(_locations[i].LocationsId, result[i].LocationsId);
                Assert.AreEqual(_locations[i].City, result[i].City);
                Assert.AreEqual(_locations[i].CarsAvailable, result[i].CarsAvailable);
                Assert.AreEqual(_locations[i].Description, result[i].Description);
                Assert.AreEqual(_locations[i].Image, result[i].Image);
            }
        }



        [TestMethod]
        public void AddLocation_CallsCreateMethodOnce()
        {
            // Arrange
            var newLocation = new Locations
            {
                LocationsId = 3,
                City = "Timisoara",
                CarsAvailable = 3,
                Description = "new",
                Image = "https://example.com/image3.jpg"
            };

            // Act
            _locationService.AddLocation(newLocation);

            // Assert
            _mockLocationRepository.Verify(x => x.Create(It.Is<Locations>(loc =>
                loc.LocationsId == newLocation.LocationsId &&
                loc.City == newLocation.City &&
                loc.CarsAvailable == newLocation.CarsAvailable &&
                loc.Description == newLocation.Description &&
                loc.Image == newLocation.Image
            )), Times.Once);
        }


        [TestMethod]
        public void DeleteLocation_CallsDeleteMethodOnce()
        {
            // Arrange
            var locationToDelete = _locations[0];

            // Act
            _locationService.DeleteLocation(locationToDelete);

            // Assert
            _mockLocationRepository.Verify(x => x.Delete(It.Is<Locations>(loc =>
                loc.LocationsId == locationToDelete.LocationsId &&
                loc.City == locationToDelete.City &&
                loc.CarsAvailable == locationToDelete.CarsAvailable &&
                loc.Description == locationToDelete.Description &&
                loc.Image == locationToDelete.Image
            )), Times.Once);
        }



        [TestMethod]
        public void UpdateLocation_CallsUpdateMethodOnce()
        {
            // Arrange
            var locationToUpdate = _locations[0];
            locationToUpdate.City = "Updated City";

            // Act
            _locationService.UpdateLocation(locationToUpdate);

            // Assert
            _mockLocationRepository.Verify(x => x.Update(It.Is<Locations>(loc =>
                loc.LocationsId == locationToUpdate.LocationsId &&
                loc.City == locationToUpdate.City &&
                loc.CarsAvailable == locationToUpdate.CarsAvailable &&
                loc.Description == locationToUpdate.Description &&
                loc.Image == locationToUpdate.Image
            )), Times.Once);
        }
    }
}
