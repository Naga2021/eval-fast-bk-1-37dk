using FortCode.Controllers;
using FortCode.Data.Entities;
using FortCode.Data.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FortCode.UnitTests
{
    public class CityTest
    {
        private readonly Mock<ICityRepository> _cityRepository;
        private readonly CityController _cityController;
        public CityTest()
        {
            _cityRepository = new Mock<ICityRepository>();
            _cityController = new CityController(_cityRepository.Object);
        }

        [Fact]
        public async Task Add_AddGivenCity_ReturnTrue()
        {
            var city = Mock.Of<City>(city => city.Id == 1 && city.CityName == "Hyderabad" && city.Country == "India");
            _cityRepository.Setup(city => city.Save(It.IsAny<City>())).ReturnsAsync(true);

            var result = await _cityController.Add(city);
            Assert.True(result);
        }

        [Fact]
        public async Task GetCities_GetAllCities_CityCollection()
        {
            var cities = new List<City>();
            cities.Add(new City { Id=1,CityName = "Hyderabad", Country = "India" });

             _cityRepository.Setup(city => city.GetAll()).ReturnsAsync(cities);

            var result = await _cityController.GetCities();

            Assert.Equal(cities, result);
        }

        [Fact]
        public void Remove_RemoveGivenCityById_ReturnTrue()
        {
            var city = Mock.Of<City>(city => city.Id == 1 && city.CityName == "Hyderabad" && city.Country == "India");

            _cityRepository.Setup(city => city.Get(It.IsAny<int>())).ReturnsAsync(city);
            _cityRepository.Setup(city => city.Remove(It.IsAny<City>())).Returns(true);

            var result= _cityController.Remove(1);
            Assert.True(result);
        }
    }
}
