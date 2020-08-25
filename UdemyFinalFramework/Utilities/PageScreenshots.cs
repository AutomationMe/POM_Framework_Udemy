using NUnit.Framework;
using OpenQA.Selenium;


namespace UdemyFinalFramework.Utilities
{
    public class PageScreenshots
    {
            public void ScreenshotCapture()
                {
            var TCname = TestContext.CurrentContext.Test.Name;
            Screenshot img = ((ITakesScreenshot)Initialise._driver).GetScreenshot();
            //Save the screenshot
       img.SaveAsFile("E:\\Thankam\\Automation_Selenium\\POM_Framework\\UdemyFinalFramework\\UdemyFinalFramework\\UdemyFinalFramework\\Screenshots\\"+TCname+".png", OpenQA.Selenium.ScreenshotImageFormat.Png);

                }
    }
}
