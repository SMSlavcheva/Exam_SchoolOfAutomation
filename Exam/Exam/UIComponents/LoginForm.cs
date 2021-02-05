using OpenQA.Selenium;

namespace BasicSelenium.UIComponents
{
    class LoginForm
    {
        public static readonly By EMIAL_FIELD = By.Name("email");

        public static readonly By PASSWORD_FIELD = By.Name("pass");

        public static readonly By LOGIN_BUTTON = By.Name("btn-login");

        public static readonly By REGISTER_BUTTON = By.CssSelector("a[name='btn-login']");

        public static readonly By ALERT_MESSAGE = By.ClassName("alert-danger");

        public static readonly By TITLE = By.TagName("h2");
    }
}
