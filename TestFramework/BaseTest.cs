using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Drawing;

namespace TestFramework
{
    public abstract class BaseTest
    {
        private string PortalUrl
        {
            get
            {
                var urlProperty = TestContext.Parameters["PortalUrl"];
                if (urlProperty != null)
                    return urlProperty;
                else
                    return "http://automationpractice.com";
            }
        }

        //tu taka podstawowa zabawa w Extent Reports

            /*
        public static ExtentReports extent;

        public static ExtentTest test;

        
        [OneTimeSetUp]
        public void SetUpOnce()
        {


            var htmlReporter = new ExtentHtmlReporter("C:\\Nowy folder\\blabla.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        */

        [SetUp]
        public void SetUp()
        {

            if (TestContext.Parameters["browser"] == null)
            {

                var options1 = new ChromeOptions();
                options1.AddArgument("--disable-extensions");
                options1.SetLoggingPreference(LogType.Browser, LogLevel.All);
                DriverContext.Driver = new ChromeDriver(options1);
                DriverContext.Driver.Manage().Window.Maximize();
                NavigateToPortalWebiste(PortalUrl);
            }

            else if (TestContext.Parameters["browser"].ToString() == "chrome")
            {
                var options1 = new ChromeOptions();
                options1.AddArgument("--disable-extensions");
                options1.AddArgument("--disable-infobars");
                options1.SetLoggingPreference(LogType.Browser, LogLevel.All);
                DriverContext.Driver = new ChromeDriver(options1);
                DriverContext.Driver.Manage().Window.Maximize();
                DriverContext.Driver.Manage().Cookies.DeleteAllCookies();
                NavigateToPortalWebiste(PortalUrl);
            }
            else if (TestContext.Parameters["browser"].ToString() == "ie")
            {
                InternetExplorerOptions options = new InternetExplorerOptions() { EnsureCleanSession = true };
                options.BrowserCommandLineArguments = "-private";
                options.BrowserCommandLineArguments = "no-sandbox";
                DriverContext.Driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory, options, TimeSpan.FromMinutes(2));
                DriverContext.Driver.Manage().Cookies.DeleteAllCookies();
                DriverContext.Driver.Manage().Window.Size = new Size(1920, 1080);
                NavigateToPortalWebiste(PortalUrl);
            }


        }


        [TearDown]
        public void Cleanup()
        {

            //tu coś bawiłem się w extent reports bo nigdy nie używałem i w sumie jakiś podstawowy raport działa
            /*
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result
                .StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if(status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(Status.Fail, status + " " + errorMessage);
            }
            else
            {
                test.Log(Status.Pass, status + " " + errorMessage);
            }
            extent.Flush();
            */
            DriverContext.Driver.Close();
            DriverContext.Driver.Quit();
            DriverContext.Driver.Dispose();


        }

        public void NavigateToPortalWebiste(string url)
        {
            DriverContext.Driver.Url = url;
        }



    }
}
