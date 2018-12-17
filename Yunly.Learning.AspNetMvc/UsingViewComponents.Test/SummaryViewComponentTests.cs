using System;
using Xunit;
using Moq;
using System.Linq;
using System.Collections.Generic;
using UsingViewComponents.Components;
using UsingViewComponents.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace UsingViewComponents.Test
{
    public class SummaryViewComponentTests
    {
        [Fact]
        public void TestSummary()
        {
            //arrange
            var mock = new Mock<ICityRepository>();

            mock.Setup(m => m.Cities).Returns(new List<City> {
                new City { Population = 100 },
                new City { Population = 20000 },
                new City { Population = 1000000 },
                new City { Population = 500000 }
            });

            var viewComponent = new CitySummary(mock.Object);

            //act
            var result = viewComponent.Invoke(false) as ViewViewComponentResult;

            //assert
            Assert.IsType<CityViewModel>(result.ViewData.Model);
            Assert.Equal(4, ((CityViewModel)result.ViewData.Model).Cities);
            Assert.Equal();

        }
    }
}
