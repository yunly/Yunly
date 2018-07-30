using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Yunly.Net.SeleniumAPI
{
    public class SeleniumFactory
    {
        public static IWebDriver createChromeDriver(TimeSpan timeOut, params string[] optionsArguments)
        {

            ChromeOptions options = new ChromeOptions();

            options.AddArguments(optionsArguments);


            // options.AddArgument("headless");
            //options.AddArgument("no-sandbox");

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();



            IWebDriver driver = new ChromeDriver(service, options, timeOut);

            return driver;
        }

        public static IWebDriver createChromeDriver()
        {
            return createChromeDriver(new TimeSpan(0, 1, 0), new string[] { });
        }

    }
}
