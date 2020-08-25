using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using System.Threading;
using UdemyFinalFramework.Pages;
using UdemyFinalFramework.Utilities;

namespace UdemyFinalFramework
{
    [TestFixture]
    public class TestCases : AutomationPractice_Contact
    {
        PageScreenshots _ps;
        RandomStuff _rs;
        public static ExtentReports extent;
        public static ExtentTest test;
        

        [OneTimeSetUp]

        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"E:\Thankam\Automation_Selenium\POM_Framework\UdemyFinalFramework\UdemyFinalFramework\UdemyFinalFramework\Reports\Udemy_Test_Final_Report");
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
      public void beforetests()
        {
            var test = TestContext.CurrentContext.Test.Name;
            string url = ConfigurationManager.AppSettings.Get(test);

            Initialise.Drivers("chrome", url);
        }

        [Test]
        public void TC1_ContactUs()
        {
            test = extent.CreateTest("TC1_ContactUs").Info("Test Started");
           bool status= contact();
            test.Log(Status.Info, "Contact Link is successfully clicked");

                IJavaScriptExecutor js = (IJavaScriptExecutor)Initialise._driver;
                js.ExecuteScript("javascript:window.scrollBy(0,200)");

                        _ps = new PageScreenshots();
                        _ps.ScreenshotCapture();            

            ContactPageAvail();
          }


        [Test]
        public void TC2_Random_Stuff()
        {
            test = extent.CreateTest("TC2_Random_Stuff").Info("Test Started");
            _rs = new RandomStuff();

            bool status = _rs.SubmitValue("Pinki", "Pinki@gmail.com", "New");
            Assert.IsTrue(status);
            Thread.Sleep(2000);
          
            test.Log(Status.Info, "Values are successfully submitted");

        }

        [TearDown]
        public void End()
        {

            Initialise._driver.Quit();

        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
       
        }
        }


}
