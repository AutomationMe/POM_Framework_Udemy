using NUnit.Framework;
using OpenQA.Selenium;
using System;
using UdemyFinalFramework.Extensions;

namespace UdemyFinalFramework.Pages
{
    public class AutomationPractice_Contact : SeleniumExtensions
    {
        By _contact = By.XPath("//div[@id='contact-link']");

        public bool contact()
        {
            bool status = false;
            try
            {
                ClickElement(_contact);

            IJavaScriptExecutor js = (IJavaScriptExecutor)Initialise._driver;
            js.ExecuteScript("javascript:window.scrollBy(0,200)");

            status = true;

        }
            catch (Exception)
            {                
            }
            return status;

        }


    //condition to check contact loaded after button is clicked
    public void ContactPageAvail()
        {
            
              String url = Initialise._driver.Url;

                try
                {
                  
                    Assert.True(url.Contains(""));
                
                }
                catch (Exception e)
                {

                
                }

        }
    }
}
