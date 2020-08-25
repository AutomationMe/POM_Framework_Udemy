using NUnit.Framework;
using OpenQA.Selenium;
using System;
using UdemyFinalFramework.Extensions;
using UdemyFinalFramework.Utilities;

namespace UdemyFinalFramework.Pages
{
    public class RandomStuff: SeleniumExtensions
    {
        PageScreenshots _Sc;

        By _name = By.XPath("//input[@id='et_pb_contact_name_0']");
        By _email = By.XPath("//input[@id='et_pb_contact_email_0']");
        By _message = By.XPath("//textarea[@id='et_pb_contact_message_0']");
        By _robocheck = By.XPath("//input[@name='et_pb_contact_captcha_0']");
        By _captcha = By.XPath("//span[@class='et_pb_contact_captcha_question']");
        By _submitButton = By.XPath("//button[@name='et_builder_submit_button']");

        public bool SubmitValue(string uname, string uemail, string umsg)
        {

            bool status = false;
            try
            {

                IJavaScriptExecutor js = (IJavaScriptExecutor)Initialise._driver;
                js.ExecuteScript("javascript:window.scrollBy(0,200)");
               
                EnterText(uname, _name);
                EnterText(uemail, _email);
                EnterText(umsg, _message);
                //calculate captcha result
                int unum = calculate_captcha(_captcha);
                EnterText_Captcha(unum, _robocheck);

                _Sc = new PageScreenshots();
                _Sc.ScreenshotCapture();

                ClickElement(_submitButton);
                status = true;

            }
            catch (Exception e)
            {

                
            }return status;

        }

        public int calculate_captcha(By _captcha)
        {
            string num = Initialise._driver.FindElements(_captcha)[0].Text;

            string[] splitString = num.Split('+');

            string num1 = splitString[0].Trim();
            string num2 = splitString[1].Trim();

            int sum_result = Int32.Parse(num1) + Int32.Parse(num2);

            return sum_result;
            
        }
    }

}
