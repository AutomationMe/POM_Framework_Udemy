using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace UdemyFinalFramework
{
    public static class Initialise
    {
        public static IWebDriver _driver { get; set; }


        public static void Drivers(string browser ,string url)
        {
          

            switch(browser)
            {
                case "chrome":  _driver = new ChromeDriver();
                                chromebrowser(url);break;

                case "IE":      _driver = new InternetExplorerDriver();
                                IEbrowser(url);break;

                case "FF":      _driver = new FirefoxDriver();
                                FFbrowser(url);break;

                default:break;
            }



        }

            public static void chromebrowser(string url)
            {
                _driver.Navigate().GoToUrl(url);
                _driver.Manage().Window.Maximize();
            }

                    public static void IEbrowser(string url)
                    {
                        _driver.Navigate().GoToUrl(url);
                        _driver.Manage().Window.Maximize();
                    }

                            public static void FFbrowser(string url)
                            {
                                _driver.Navigate().GoToUrl(url);
                                _driver.Manage().Window.Maximize();
                            }

    }


}
