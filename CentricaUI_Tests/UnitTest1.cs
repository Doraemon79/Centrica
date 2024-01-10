using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CentricaUI_Tests
{
    [TestClass]
    public class UnitTest1 : TestSession
    {
        private static WindowsElement listView;
        private static WindowsElement button;


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);

            listView = session.FindElementByAccessibilityId("DistrictsListView");
            button = session.FindElementByAccessibilityId("bRefresh");

        }

        [TestMethod]
        public void TestMethod1()
        {
            ObservableCollection<string> _districts = new ObservableCollection<string>();
            _districts.Add("Test2");
            var labelView = session.FindElementByAccessibilityId("DistrictLabel");
            listView.SendKeys("Test");
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
            var gridRowElements = listView.FindElementsByClassName(@"GridViewRow").ToList();


            Assert.AreEqual("Test", labelView.Text.ToString());
            //Assert.IsTrue(gridRowElements.Count == 3, "Expected rows: 3, Actual rows: " + gridRowElements.Count);

            listView.Click();

            desktopSession.FindElementByName("Delete Row").Click();

            gridRowElements = listView.FindElementsByClassName(@"GridViewRow").ToList();
            Assert.IsTrue(gridRowElements.Count == 2, "Expected rows: 2, Actual rows: " + gridRowElements.Count);
        }

        //protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        //private const string WpfAppId = @"C:\Repos\Centrica_Test\CentricaShops\bin\Debug\net8.0-windows\CentricaShops.exe";

        //protected static WindowsDriver<WindowsElement> session;

        //[ClassInitialize]
        //public static void Setup(TestContext context)
        //{
        //    if (session == null)
        //    {

        ////        DesiredCapabilities appCapabilities = new DesiredCapabilities();
        ////        appCapabilities.SetCapability("app", WpfAppId);
        ////        appCapabilities.SetCapability("deviceName", "WindowsPC");

        ////        var appiumOptions = new AppiumOptions();
        ////        appiumOptions.AddAdditionalCapability("app", WpfAppId);
        ////        appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
        ////        session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
        ////        session.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
        //    }
        //}


        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var tb = session.FindElement(By.Name("bSaleperson"));
        //    tb.SendKeys("Engineer");

        //    // Act
        //    session.FindElement(By.Name("InfoButton")).Click();
        //    //var actual = label.Text;

        //    Assert.AreEqual("Engineer", tb.Text);
        //}


        //[TestInitialize]

        //[TestMethod]
        //public void AddNameToTextBox()
        //{
        //    //var txtName = session.FindElementByAccessibilityId("txtName");

        //    var ExpectedResult = "";
        //    WebDriverWait wdv = new WebDriverWait(session, TimeSpan.FromSeconds(10));
        //   var txtPwd=  session.FindElementByAccessibilityId("DistrictsListView");
        //    txtPwd.SendKeys("Test1");
        //    wdv.Until(x => txtPwd.Displayed);
        //    //var txtDistrictsListView = session.FindElementByAccessibilityId("DistrictsListView");

        //    //session.FindElementByAccessibilityId("bRefresh").SendKeys("TestMatteo");
        //    //var sess = session.FindElementByAccessibilityId("DistrictsListView");

        //    var btn = session.FindElementByAccessibilityId("bRefresh");
        //    btn.Click();
        //    txtPwd.Clear();

        //    var label= session.FindElementByAccessibilityId("DistrictLabel");
        //    //label.SendKeys("Test2");
        //    //sess.SendKeys("Test");
        //    Assert.AreEqual("England", txtPwd.Text );
        //}


    }
}
