using CentricaShops.Models;
using CentricaShops.ViewModels;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace CentricaStore_Tests
{
    public class ShowDistrictTests : TestSession
    {
        private readonly SalePersonProcessor sut;
        private readonly ShowDistrictViewModel _viewModel;
        private static WindowsElement listView;
        private static WindowsElement button;
        private readonly GeneralDistrict _generalDistrict=new GeneralDistrict("TestStores");


        ObservableCollection<string> _districts = new ObservableCollection<string>();
        
        public ShowDistrictTests()
        {
            sut = new SalePersonProcessor();
            _districts.Add("Testtest");
            _generalDistrict.SetDistricts(_districts.ToList());
            //_viewModel = new ShowDistrictViewModel(_generalDistrict);
            Setup();
        }



        [Fact]
        public void AddSalePerson_IsPrimary()
        {
            //Arrange
            //ObservableCollection<DistrictAndSalePerson> _districts = new ObservableCollection<DistrictAndSalePerson>();
            //SalepersonAndRole salepersonAndRole = new SalepersonAndRole("SalePersonTest", true);
            ////Act
            //_districts = sut.AddSalePerson("districtTest", salepersonAndRole, _districts);
            ////Assert
            //Assert.Equal(1, _districts.Count);
            //Assert.Equal("SalePersonTest", _districts.First().salepersonAndRole.SalePerson);
        }

        //[Fact]
        //public void ProcessSalePerson_IsPrimary()
        //{
        //    //Arrange
        //    ObservableCollection<DistrictAndSalePerson> _districts = new ObservableCollection<DistrictAndSalePerson>();
        //    _districts.Add(districtAndSalePerson1);
        //    SalepersonAndRole salepersonAndRole = new SalepersonAndRole("SalePersonTest", true);
        //    //Act
        //    _districts = sut.ProcessSalePerson("District1", salepersonAndRole, _districts);
        //    //Assert
        //    Assert.Equal(1, _districts.Count);
        //    Assert.Equal("SalePersonTest", _districts.First().salepersonAndRole.SalePerson);
        //}

        [Fact]
        public void TestUI()
        {
            listView = session.FindElementByAccessibilityId(@"DistrictsListView");
 
    
            listView.SendKeys("Test6");
            var tstgrid = listView.FindElementsByClassName(@"ListViewItem");

            button = session.FindElementByAccessibilityId("bRefresh");
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            var tsttxt=listView.Text;
            //ObservableCollection<string> _districts = new ObservableCollection<string>();
            //_districts.Add("Test2");
            button.SendKeys("Test4");
       
            button.Click();
            //button.SendKeys("Test4");
            var labelView = session.FindElementByAccessibilityId("DistrictLabel");
            listView.SendKeys("Test");
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
                var gridRowElements = listView.FindElementsByClassName(@"GridViewRow").ToList();
          

            
            var tst = tstgrid[1];
            Assert.Equal("Test3", labelView.Text.ToString());
                //Assert.IsTrue(gridRowElements.Count == 3, "Expected rows: 3, Actual rows: " + gridRowElements.Count);

                listView.Click();

                desktopSession.FindElementByName("Delete Row").Click();

                gridRowElements = listView.FindElementsByClassName(@"GridViewRow").ToList();
                Assert.True(gridRowElements.Count == 2, "Expected rows: 2, Actual rows: " + gridRowElements.Count);
            
        }

    }
}