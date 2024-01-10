using CentricaStoresApi.BudsinessLogic;
using CentricaStoresApi.Controllers;
using CentricaStoresApi.Data;
using CentricaStoresApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.ObjectModel;

namespace API_test;

public class ApisTest
{


    [Fact]
    public async Task TestGetAll_returns_True()
    {
        //Arrange
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        var resultCheckerMock = new Mock<IResultChecker>();
        ObservableCollection<string> _districts = new ObservableCollection<string>();
        _districts.Add("Test1");
        _districts.Add("Test2");

        repositoryMock.Setup(r => r.GetAll())
        .Returns(Task.FromResult(_districts.AsEnumerable()));
        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object, resultCheckerMock.Object);

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
        var resultCheckerMock = new Mock<IResultChecker>();
        ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>();

        StorePersonDistrictModel test1 = new StorePersonDistrictModel();
        test1.DistrictName = "Test1";
        test1.StoreName = "Test";
        test1.SalePerson = "TestPerson1";
        test1.IsPrimary = true;

        StorePersonDistrictModel test2 = new StorePersonDistrictModel();
        test1.DistrictName = "Test1";
        test1.StoreName = "Test";
        test1.SalePerson = "TestPerson1";
        test1.IsPrimary = true;

        _districts.Add(test1);
        _districts.Add(test2);

        repositoryMock.Setup(r => r.GetDetailsByDistrict("Austria"))
        .Returns(Task.FromResult(_districts.AsEnumerable()));
        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object, resultCheckerMock.Object);

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
        //Arrange
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        var resultCheckerMock = new Mock<IResultChecker>();
        ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>();

        StorePersonDistrictModel test1 = new StorePersonDistrictModel();
        test1.DistrictName = "Test1";
        test1.StoreName = "Test";
        test1.SalePerson = "TestPerson1";
        test1.IsPrimary = true;

        StorePersonDistrictModel test2 = new StorePersonDistrictModel();
        test2.DistrictName = "Test1";
        test2.StoreName = "Test";
        test2.SalePerson = "TestPerson1";
        test2.IsPrimary = true;

        _districts.Add(test1);
        _districts.Add(test2);

        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object, resultCheckerMock.Object);
        repositoryMock.Setup(r => r.GetDetailsByDistrict("Austria")).Returns(Task.FromResult(_districts.AsEnumerable()));
        resultCheckerMock.Setup(r => r.PresentInDistrict(_districts, "Chuck Norris")).Returns(false);

        var districtPerson = new DistrictSalePerson() { districtname = "Test1", name = "Chuck Norris" };
        ////Act

        var result = await controller.InsertSalePerson(districtPerson);

        //Assert
        var createdResult = Assert.IsType<CreatedResult>(result.Result);
    }

    [Fact]
    public async Task TestUpdateSalePerson_returns_True()
    {
        //Arrange
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        var repositoryChecker = new Mock<IResultChecker>();
        ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>();

        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object, repositoryChecker.Object);
        var districtPerson = new DistrictSalePerson() { districtname = "Austria", name = "Chuck Norris" };
        ////Act

        var result = await controller.UpdateSalePerson(districtPerson);

        //Assert
        var okResult = Assert.IsType<NoContentResult>(result.Result);
    }

    [Fact]
    public async Task TestDeleteSalePerson_returns_True()
    {
        //Arrange
        var repositoryMock = new Mock<IDistrictsRepo>();
        var loggerMock = new Mock<ILogger<SalePersonController>>();
        var resultCheckerMock = new Mock<IResultChecker>();
        //ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>();
        StorePersonDistrictModel test1 = new StorePersonDistrictModel();
        test1.DistrictName = "Test1";
        test1.StoreName = "Test";
        test1.SalePerson = "TestPerson1";
        test1.IsPrimary = true;

        StorePersonDistrictModel test2 = new StorePersonDistrictModel();
        test2.DistrictName = "Test1";
        test2.StoreName = "Test";
        test2.SalePerson = "Franco Nero";
        test2.IsPrimary = false;

        //_districts.Add(test1);
        //_districts.Add(test2);

        ObservableCollection<StorePersonDistrictModel> _districts = new ObservableCollection<StorePersonDistrictModel>()
        { test1,test2};

        var controller = new SalePersonController(loggerMock.Object, repositoryMock.Object, resultCheckerMock.Object);
        repositoryMock.Setup(r => r.GetDetailsByDistrict("Test1")).Returns(Task.FromResult(_districts.AsEnumerable()));
        resultCheckerMock.Setup(r => r.PresentInDistrict(_districts, "Franco Nero")).Returns(true);
        resultCheckerMock.Setup(r => r.SalePersonIsPrimary(_districts, "Franco Nero")).Returns(false);


        var districtPerson = new DistrictSalePerson() { districtname = "Test1", name = "Franco Nero" };
        ////Act

        var result = await controller.DeleteSalePerson(districtPerson);
        _districts.Remove(test2);

        //Assert
        var okResult = Assert.IsType<OkResult>(result);
        okResult.StatusCode.Should().Be(200);
    }

}