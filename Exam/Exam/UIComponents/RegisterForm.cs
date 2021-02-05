using OpenQA.Selenium;

namespace BasicSelenium.UIComponents
{
    class RegisterForm
    {
        public static readonly By FIRST_NAME_FIELD = By.Name("first_name");

        public static readonly By SIR_NAME_FIELD = By.Name("sir_name");

        public static readonly By EMAiL_FIELD = By.Name("email");

        public static readonly By PASSWORD_FIELD = By.Name("pass");

        public static readonly By COUNTRY_FIELD = By.Name("country");

        public static readonly By CITY_FIELD = By.Id("city");

        public static readonly By TERMS_OF_SERVICE_CHECKBOX = By.Id("TOS");

        public static readonly By LOGIN_BUTTON = By.Name("btn-login");

        public static readonly By REGISTER_BUTTON = By.Id("reg");

        public static readonly By TITLE = By.TagName("h2");

        public static readonly By ALERT_MESSAGE = By.ClassName("alert-warning");

        public static readonly By MR_RADIO_BUTTON = By.CssSelector("[class] .radio-inline:nth-child(2) [type]");

        public static readonly By MRS_RADIO_BUTTON = By.CssSelector("[class] .radio-inline:nth-child(3) [type]");
    }
}
