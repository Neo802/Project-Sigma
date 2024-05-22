using Moq;
using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjectRunAwayTest
{
    [TestClass]
    public class CarsTest
    {
        private Mock<IRepositoryWrapper> _mockWrapper;
        private Mock<ICarsRepository> _mockCarsRepository;
        private Mock<IFeaturesRepository> _mockFeaturesRepository;
        private Mock<IAvailabilityRepository> _mockAvailabilityRepository;
        private List<Cars> _cars;
        private List<Features> _features;
        private List<Availability> _availabilities;
        private CarsService _carsService;

        [TestInitialize]
        public void Setup()
        {
            _mockWrapper = new Mock<IRepositoryWrapper>();
            _mockCarsRepository = new Mock<ICarsRepository>();
            _mockFeaturesRepository = new Mock<IFeaturesRepository>();
            _mockAvailabilityRepository = new Mock<IAvailabilityRepository>();
            _carsService = new CarsService(_mockWrapper.Object);

            _cars = new List<Cars>
            {
                new Cars
                {
                    CarsId = 1,
                    Manufacturer = "Mercedes-Benz",
                    Model = "E Class",
                    Description = "",
                    Image = "",
                    Fuel = "Petrol",
                    Seats = "4",
                    Gear = "Automatic",
                    Type = "Sedan",
                    Doors = "5",
                    PriceCar = 300,
                    TankCapacity = 50
                },
                new Cars
                {
                    CarsId = 2,
                    Manufacturer = "Audi",
                    Model = "A4",
                    Description = "A beautiful car",
                    Image = "",
                    Fuel = "Diesel",
                    Seats = "4",
                    Gear = "Manual",
                    Type = "Estate",
                    Doors = "5",
                    PriceCar = 250,
                    TankCapacity = 65
                }
            };

            _features = new List<Features>
            {
                new Features { FeaturesId = 1, CarsId = 1, SunRoof = "Sunroof" },
                new Features { FeaturesId = 2, CarsId = 1, MaterialOfTheSeats = "Leather seats" },
                new Features { FeaturesId = 3, CarsId = 2, Navigation = "Bluetooth" }
            };

            _availabilities = new List<Availability>
            {
                new Availability { CarsId = 1, LocationsId = 1, DateStart = DateOnly.FromDateTime(System.DateTime.Now), DateEnd = DateOnly.FromDateTime(System.DateTime.Now.AddDays(1)) },
                new Availability { CarsId = 2, LocationsId = 2, DateStart = DateOnly.FromDateTime(System.DateTime.Now), DateEnd = DateOnly.FromDateTime(System.DateTime.Now.AddDays(1))}
            };

            _mockWrapper.Setup(x => x.CarsRepository).Returns(_mockCarsRepository.Object);
            _mockWrapper.Setup(x => x.FeaturesRepository).Returns(_mockFeaturesRepository.Object);
            _mockWrapper.Setup(x => x.AvailabilityRepository).Returns(_mockAvailabilityRepository.Object);
        }

        [TestMethod]
        public void GetCarsById_ReturnsCorrectCar()
        {
            // Arrange
            var carId = 1;
            var car = _cars.First(c => c.CarsId == carId);
            var features = _features.Where(f => f.CarsId == carId).ToList();

            _mockCarsRepository.Setup(repo => repo.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Cars, bool>>>()))
                .Returns(new List<Cars> { car }.AsQueryable());

            _mockFeaturesRepository.Setup(repo => repo.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Features, bool>>>()))
                .Returns(features.AsQueryable());

            // Act
            var result = _carsService.GetCarsById(carId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(car.CarsId, result.CarsId);
            Assert.AreEqual(2, result.Features.Count);
            Assert.IsTrue(result.Features.Any(f => f.SunRoof == "Sunroof"));
            Assert.IsTrue(result.Features.Any(f => f.MaterialOfTheSeats == "Leather seats"));
        }

        [TestMethod]
        public void GetAvailabilityByCarId_ReturnsCorrectAvailability()
        {
            // Arrange
            var carId = 1;
            var availability = _availabilities.First(a => a.CarsId == carId);

            _mockAvailabilityRepository.Setup(repo => repo.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Availability, bool>>>()))
                .Returns(new List<Availability> { availability }.AsQueryable());

            // Act
            var result = _carsService.GetAvailabilityByCarId(carId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(availability.CarsId, result.CarsId);
            Assert.AreEqual(availability.LocationsId, result.LocationsId);
            Assert.AreEqual(availability.DateStart, result.DateStart);
            Assert.AreEqual(availability.DateEnd, result.DateEnd);
        }

        [TestMethod]
        public void AddCars_CallsCreateMethodOnce()
        {
            // Arrange
            var newCar = new Cars
            {
                CarsId = 3,
                Manufacturer = "BMW",
                Model = "X5",
                Description = "Luxury SUV",
                Image = "",
                Fuel = "Petrol",
                Seats = "5",
                Gear = "Automatic",
                Type = "SUV",
                Doors = "5",
                PriceCar = 350,
                TankCapacity = 70
            };

            // Act
            var result = _carsService.AddCars(newCar);

            // Assert
            Assert.AreEqual(string.Empty, result);
            _mockCarsRepository.Verify(x => x.Create(It.Is<Cars>(car =>
                car.CarsId == newCar.CarsId &&
                car.Manufacturer == newCar.Manufacturer &&
                car.Model == newCar.Model &&
                car.Description == newCar.Description &&
                car.Fuel == newCar.Fuel &&
                car.Seats == newCar.Seats &&
                car.Gear == newCar.Gear &&
                car.Type == newCar.Type &&
                car.Doors == newCar.Doors &&
                car.PriceCar == newCar.PriceCar &&
                car.TankCapacity == newCar.TankCapacity
            )), Times.Once);
            _mockWrapper.Verify(x => x.Save(), Times.Once);
        }
        [TestMethod]
        public void UpdateCars_CallsUpdateMethodOnce()
        {
            // Arrange
            var updatedCar = new Cars
            {
                CarsId = 1,
                Manufacturer = "Mercedes-Benz",
                Model = "E Class",
                Description = "Updated description",
                Image = "new_image.jpg",
                Fuel = "Petrol",
                Seats = "4",
                Gear = "Automatic",
                Type = "Sedan",
                Doors = "5",
                PriceCar = 320,
                TankCapacity = 55
            };

            // Act
            _carsService.UpdateCars(updatedCar);

            // Assert
            _mockCarsRepository.Verify(x => x.Update(It.Is<Cars>(car =>
                car.CarsId == updatedCar.CarsId &&
                car.Manufacturer == updatedCar.Manufacturer &&
                car.Model == updatedCar.Model &&
                car.Description == updatedCar.Description &&
                car.Image == updatedCar.Image &&
                car.Fuel == updatedCar.Fuel &&
                car.Seats == updatedCar.Seats &&
                car.Gear == updatedCar.Gear &&
                car.Type == updatedCar.Type &&
                car.Doors == updatedCar.Doors &&
                car.PriceCar == updatedCar.PriceCar &&
                car.TankCapacity == updatedCar.TankCapacity
            )), Times.Once);
            _mockWrapper.Verify(x => x.Save(), Times.Once);


        }

        [TestMethod]
        public void DeleteCars_CallsDeleteMethodOnce()
        {
            // Arrange
            var carToDelete = _cars.First();

            // Act
            _carsService.DeleteCars(carToDelete);

            // Assert
            _mockCarsRepository.Verify(x => x.Delete(It.Is<Cars>(car =>
                car.CarsId == carToDelete.CarsId &&
                car.Manufacturer == carToDelete.Manufacturer &&
                car.Model == carToDelete.Model &&
                car.Description == carToDelete.Description &&
                car.Image == carToDelete.Image &&
                car.Fuel == carToDelete.Fuel &&
                car.Seats == carToDelete.Seats &&
                car.Gear == carToDelete.Gear &&
                car.Type == carToDelete.Type &&
                car.Doors == carToDelete.Doors &&
                car.PriceCar == carToDelete.PriceCar &&
                car.TankCapacity == carToDelete.TankCapacity
            )), Times.Once);
            _mockWrapper.Verify(x => x.Save(), Times.Once);
        }
    }
}
