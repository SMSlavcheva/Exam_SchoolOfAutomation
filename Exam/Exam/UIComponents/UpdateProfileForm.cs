using OpenQA.Selenium;

namespace BasicSelenium.UIComponents
{
    class UpdateProfileForm
    {
        public static readonly By MR_RADIO_BUTTON = By.CssSelector("[class] .radio-inline:nth-child(2) [type]");

        public static readonly By MRS_RADIO_BUTTON = By.CssSelector("[class] .radio-inline:nth-child(3) [type]");

        public static readonly By FIRST_NAME_FIELD = By.Name("first_name");

        public static readonly By SIR_NAME_FIELD = By.Name("sir_name");

        public static readonly By COUNTRY_FIELD = By.Name("country");

        public static readonly By CITY_FIELD = By.Name("city");

        public static readonly By UPDATE_BUTTON = By.Id("Update");

        public static readonly By TITLE = By.TagName("h2");
    }
}
