using OpenQA.Selenium;
using System;
using System.Threading;

namespace UdemyFinalFramework.Extensions
{
    public class SeleniumExtensions
    {
        //element is enabled
        public bool IsEnabled(By element)
        {
            bool available = false;
            int count = 5;
            while (count > 0)
            {
                try
                {
                    available = Initialise._driver.FindElement(element).Enabled;
                    break;
                }
                catch (Exception)
                {

                    Thread.Sleep(2);
                    count -= 1;
                }

            }
            return available;
       

        }
        //Enter values into Text Boxes
        public void EnterText(string _text,By element)
        {
            if (IsEnabled(element))
            {
                Initialise._driver.FindElement(element).Clear();
                Initialise._driver.FindElement(element).SendKeys(_text);
            }
        }
        public void EnterText_Captcha(int _text, By element)
        {
            if (IsEnabled(element))
            {
                Initialise._driver.FindElement(element).Clear();
                Initialise._driver.FindElement(element).SendKeys(_text.ToString());
            }
        }



        //Element which needs to be clicked

        public void ClickElement( By element)
        {
            if (IsEnabled(element))
            {
                Initialise._driver.FindElement(element).Click();
            }
        }


    }

}
