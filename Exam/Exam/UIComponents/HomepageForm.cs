using OpenQA.Selenium;

namespace BasicSelenium.UIComponents
{
    class HomepageForm
    {
        public static readonly By TITLE = By.TagName("h1");

        public static readonly By NAVBAR_USER_BUTTON = By.CssSelector("div#navbar a[role='button']");
    }
}
