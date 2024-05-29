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
    public class CarsTest
    {
        private Mock<IRepositoryWrapper> _mockWrapper;
        private Mock<ICarsRepository> _mockCarsRepository;
        private List<Cars> _cars;
        private CarsService _carsService;

        [TestInitialize]
        public void Setup()
        {
            _mockWrapper = new Mock<IRepositoryWrapper>();
            _mockCarsRepository = new Mock<ICarsRepository>();
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

            _mockWrapper.Setup(x => x.CarsRepository).Returns(_mockCarsRepository.Object);
        }

        [TestMethod]
        public void GetCarsById_ReturnsCorrectCar()
        {
            // Arrange
            _mockWrapper.Setup(x => x.CarsRepository.FindByCondition(car => car.CarsId == 1))
                .Returns(_cars.Where(car => car.CarsId == 1).AsQueryable());

            // Act
            var result = _carsService.GetCarsById(1);

            // Assert
            Assert.IsNotNull(result);
<<<<<<< Updated upstream
            Assert.AreEqual("Mercedes-Benz", result.Manufacturer);
            Assert.AreEqual("E Class", result.Model);
            Assert.AreEqual("Petrol", result.Fuel);
            Assert.AreEqual("4", result.Seats);
            Assert.AreEqual("Automatic", result.Gear);
            Assert.AreEqual("Sedan", result.Type);
            Assert.AreEqual("5", result.Doors);
            Assert.AreEqual(300, result.PriceCar);
            Assert.AreEqual(50, result.TankCapacity);
=======
            Assert.AreEqual(car.CarsId, result.CarsId);
            Assert.AreEqual(2, result.Features.Count);
            Assert.IsTrue(result.Features.Any(f => f.SunRoof == "Sunroof"));
            Assert.IsTrue(result.Features.Any(f => f.MaterialOfTheSeats == "Leather seats"));
        }

        [TestMethod]
        public void GetAvailabilityByCarId_ReturnsCorrectAvailability()
        {
            // Arrange
            var carId = 100;
            var availability = _availabilities.First(a => a.CarsId == carId);

            _mockAvailabilityRepository.Setup(repo => repo.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Availability, bool>>>()))
                .Returns(new List<Availability> { availability }.AsQueryable());

            // Act
            var result = _carsService.GetAvailabilityByCarId(carId);

            // Assert
            Assert.IsNull(result);
            //Assert.AreEqual(availability.CarsId, result.CarsId);
            //Assert.AreEqual(availability.LocationsId, result.LocationsId);
            //Assert.AreEqual(availability.DateStart, result.DateStart);
            //Assert.AreEqual(availability.DateEnd, result.DateEnd);
>>>>>>> Stashed changes
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
    }
}