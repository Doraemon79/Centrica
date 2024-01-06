using CentricaStoresApi.Controllers;
using CentricaStoresApi.Data;
using CentricaStoresApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.ObjectModel;
using System.Net;

namespace API_test;

public class ApisTest
{


    [Fact]
    public async Task TestGetAll_returns_True()
    {
        //Arrange
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        ObservableCollection<string> _districts = new ObservableCollection<string>();
        _districts.Add("Test1");
        _districts.Add("Test2");
  
        repositoryMock.Setup(r => r.GetAll())
        .Returns(Task.FromResult(_districts.AsEnumerable()));
        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object);

        ////Act
        var result = await controller.GetAll();

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        Assert.NotNull(okResult.Value);
        var model = Assert.IsAssignableFrom<ObservableCollection<string>>(okResult.Value);
        Assert.Equal(2, model.Count);
        model.First().ToString().Should().Be("Test1");
        model.First().ToString().Should().Be("Test1");
    }

    [Fact]
    public async Task TestGetDetailsByDistrict_returns_True()
    {
        //Arrange
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>();
        
        StorePersonDistrictModel test1= new StorePersonDistrictModel();
        test1.DistrictName = "Test1";
        test1.StoreName="Test";
        test1.SalePerson = "TestPerson1";
        test1.IsPrimary = true;

        StorePersonDistrictModel test2 = new StorePersonDistrictModel();
        test1.DistrictName = "Test1";
        test1.StoreName = "Test";
        test1.SalePerson = "TestPerson1";
        test1.IsPrimary = true;

        _districts.Add(test1);
        _districts.Add(test2);
        //Arrange
        repositoryMock.Setup(r => r.GetDetailsByDistrict("Austria"))
        .Returns(Task.FromResult(_districts.AsEnumerable()));
        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object);

        ////Act
        var result = await controller.GetDetailsByDistrict("Austria");

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.NotNull(okResult.Value);
        var model = Assert.IsAssignableFrom<ObservableCollection<StorePersonDistrictModel>>(okResult.Value);
        Assert.Equal(2, model.Count);
        model.First().Should().Be(test1);

    }

    [Fact]
    public async Task TestInsertSalePerson_returns_True()
    {
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>();

        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object);
        var districtPerson = new DistrictSalePerson() { districtname ="Austria", name="Chuck Norris"};
        ////Act
        
        var result = await controller.InsertSalePerson(districtPerson);

        //Assert
        var createdResult = Assert.IsType<CreatedResult>(result.Result);
    }

    [Fact]
    public async Task TestUpdateSalePerson_returns_True()
    {
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>();

        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object);
        var districtPerson = new DistrictSalePerson() { districtname = "Austria", name = "Chuck Norris" };
        ////Act

        var result = await controller.UpdateSalePerson(districtPerson);

        //Assert
        var okResult = Assert.IsType<NoContentResult>(result.Result);
    }

    [Fact]
    public async Task TestDeleteSalePerson_returns_True()
    {
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>();

        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object);
        var districtPerson = new DistrictSalePerson() { districtname = "Austria", name = "Chuck Norris" };
        ////Act

        var result = await controller.DeleteSalePerson(districtPerson);

        //Assert
        var okResult = Assert.IsType<OkResult>(result);
        okResult.StatusCode.Should().Be(200);
    }

}