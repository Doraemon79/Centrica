using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace CentricaStore_Tests
{
    public class TestSession
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string TestApp = @"C:\Repos\Centrica_Test\CentricaShops\bin\Debug\net8.0-windows\CentricaShops.exe"; // replace with the actual location of the executable file of the application you want to test 

        protected static WindowsDriver<WindowsElement> session;
        public static WindowsDriver<WindowsElement> desktopSession;

        public static void Setup()
        {
            // Launch RadGridView test application if it is not yet launched 
            if (session == null || desktopSession == null)
            {
                TearDown();

                // Create a new session to bring up the test application 
                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability("app", TestApp);
                options.AddAdditionalCapability("deviceName", "WindowsPC");
                options.AddAdditionalCapability("platformName", "Windows");

                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), options);
                Assert.NotNull(session);
                Assert.NotNull(session.SessionId);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 5- ms for at most three times 
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);

                AppiumOptions optionsDesktop = new AppiumOptions();
                optionsDesktop.AddAdditionalCapability("app", "Root");
                optionsDesktop.AddAdditionalCapability("deviceName", "WindowsPC");
                optionsDesktop.AddAdditionalCapability("ms:experimental-webdriver", true);
                desktopSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), optionsDesktop);
            }
        }

        public static void TearDown()
        {
            if (session != null)
            {
                session.Quit();
                session = null;
            }

            if (desktopSession != null)
            {
                desktopSession.Quit();
                desktopSession = null;
            }
        }
    }
}
