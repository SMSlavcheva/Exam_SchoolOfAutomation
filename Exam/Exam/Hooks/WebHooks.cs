using BasicSelenium.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BasicSelenium.Hooks
{
    [Binding]
    public sealed class WebHooks
    {
        [BeforeScenario]
        [Scope(Tag ="ui")]
        public void InitScenario()
        {
            WebDriverProvider.InitDriver();
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            IWebDriver driver = WebDriverProvider.GetPreparedDriver();
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
