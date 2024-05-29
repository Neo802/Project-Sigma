using Moq;
using ProjectRunAway.Models;
using ProjectRunAway.Repositories.Interfaces;
using ProjectRunAway.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace ProjectRunAwayTest
{
    [TestClass]
    public class ExtraTest
    {
        private Mock<IRepositoryWrapper> _mockWrapper;
        private Mock<IExtraRepository> _mockExtraRepository;
        private List<Extra> _extra;
        private ExtraService _extraService;

        [TestInitialize]
        public void Setup()
        {
            _mockWrapper = new Mock<IRepositoryWrapper>();
            _mockExtraRepository = new Mock<IExtraRepository>();
            _extraService = new ExtraService(_mockWrapper.Object);
            _extra = new List<Extra>
            {
                new Extra
                {
                    ExtraId = 1,
                    ChildSeat = "1",
                    TypeOfTires = "Racing",
                    SkiRack = "False",
                    WifiHotspot = "True",
                    SnowChains = "True",
                    RoadsideProtection = "True",
                    CarsId = 1
                },
                new Extra
                {
                    ExtraId = 2,
                    ChildSeat = "1",
                    TypeOfTires = "SUV",
                    SkiRack = "True",
                    WifiHotspot = "True",
                    SnowChains = "True",
                    RoadsideProtection = "True",
                    CarsId = 2
                },
            };

            _mockWrapper.Setup(x => x.ExtraRepository).Returns(_mockExtraRepository.Object);
        }

        [TestMethod]
        public void GetExtraById_ReturnsCorrectExtra()
        {
            // Arrange
            _mockExtraRepository.Setup(x => x.FindByCondition(extra => extra.ExtraId == 1))
                .Returns(_extra.Where(extra => extra.ExtraId == 1).AsQueryable());

            // Act
            var result = _extraService.GetExtraById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Racing", result.TypeOfTires);
            Assert.AreEqual("1", result.ChildSeat);
            Assert.AreEqual("False", result.SkiRack);
            Assert.AreEqual("True", result.WifiHotspot);
            Assert.AreEqual("True", result.SnowChains);
            Assert.AreEqual("True", result.RoadsideProtection);
            Assert.AreEqual(1, result.CarsId);
        }

        [TestMethod]
        public void GetAllExtras_ReturnsAllExtras()
        {
            // Arrange
            _mockExtraRepository.Setup(x => x.FindAll()).Returns(_extra.AsQueryable());

            // Act
            var result = _extraService.GetAllExtras();

            // Assert
            Assert.AreEqual(_extra.Count, result.Count());
            foreach (var extra in _extra)
            {
                Assert.IsTrue(result.Any(e => e.ExtraId == extra.ExtraId &&
                                              e.ChildSeat == extra.ChildSeat &&
                                              e.TypeOfTires == extra.TypeOfTires &&
                                              e.SkiRack == extra.SkiRack &&
                                              e.WifiHotspot == extra.WifiHotspot &&
                                              e.SnowChains == extra.SnowChains &&
                                              e.RoadsideProtection == extra.RoadsideProtection &&
                                              e.CarsId == extra.CarsId));
            }
        }

        [TestMethod]
        public void AddExtra_AddsExtraSuccessfully()
        {
            // Arrange
            var newExtra = new Extra
            {
                ExtraId = 3,
                ChildSeat = "2",
                TypeOfTires = "All-Terrain",
                SkiRack = "True",
                WifiHotspot = "True",
                SnowChains = "False",
                RoadsideProtection = "False",
                CarsId = 1
            };

            var car = new Cars { CarsId = 1 }; // Assuming a Cars class with CarsId property

            var mockCarsRepository = new Mock<ICarsRepository>();
            _mockWrapper.Setup(x => x.CarsRepository).Returns(mockCarsRepository.Object);
            mockCarsRepository.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<Cars, bool>>>())).Returns(new List<Cars> { car }.AsQueryable());

            _mockExtraRepository.Setup(x => x.Create(It.IsAny<Extra>()));

            // Act
            var result = _extraService.AddExtra(newExtra);

            // Assert
            Assert.AreEqual(string.Empty, result);
            _mockExtraRepository.Verify(x => x.Create(It.Is<Extra>(e => e.ExtraId == newExtra.ExtraId &&
                                                                       e.ChildSeat == newExtra.ChildSeat &&
                                                                       e.TypeOfTires == newExtra.TypeOfTires &&
                                                                       e.SkiRack == newExtra.SkiRack &&
                                                                       e.WifiHotspot == newExtra.WifiHotspot &&
                                                                       e.SnowChains == newExtra.SnowChains &&
                                                                       e.RoadsideProtection == newExtra.RoadsideProtection &&
                                                                       e.CarsId == newExtra.CarsId)), Times.Once);
            _mockWrapper.Verify(x => x.Save(), Times.Once);
        }


        [TestMethod]
        public void UpdateExtra_UpdatesExtraSuccessfully()
        {
            // Arrange
            var existingExtra = _extra.First();
            existingExtra.ChildSeat = "2";
            _mockExtraRepository.Setup(x => x.Update(existingExtra));

            // Act
            _extraService.UpdateExtra(existingExtra);

            // Assert
            _mockExtraRepository.Verify(x => x.Update(It.Is<Extra>(e => e.ExtraId == existingExtra.ExtraId &&
                                                                       e.ChildSeat == "2")), Times.Once);
        }

        [TestMethod]
        public void DeleteExtra_DeletesExtraSuccessfully()
        {
            // Arrange
            var extraToDelete = _extra.First();
            _mockExtraRepository.Setup(x => x.Delete(extraToDelete));

            // Act
            _extraService.DeleteExtra(extraToDelete);

            // Assert
            _mockExtraRepository.Verify(x => x.Delete(It.Is<Extra>(e => e.ExtraId == extraToDelete.ExtraId)), Times.Once);
        }
    }
}
