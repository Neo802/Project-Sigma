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
    }
}