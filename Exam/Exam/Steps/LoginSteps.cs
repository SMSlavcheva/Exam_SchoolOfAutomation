using BasicSelenium.Models;
using BasicSelenium.Steps.Actions;
using BasicSelenium.UIComponents;

using FluentAssertions;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BasicSelenium.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly BaseUserActions _user;
        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(BaseUserActions user, ScenarioContext scenarioContext)
        {
            _user = user;
            _scenarioContext = scenarioContext;
        }


        [Given(@"Login page is opened")]
        public void GivenLoginpageIsOpened()
        {
            _user.OpensPage("login");
            
        }

        [When(@"I type into field ""(.*)"" and ""(.*)""")]
        public void WhenITypeIntoFieldAnd(string email, string pass)
        {
            _user.TypesInto(LoginForm.EMIAL_FIELD, email);
            _user.TypesInto(LoginForm.PASSWORD_FIELD, pass);
            _scenarioContext.Add("typedEmail", email);
            _scenarioContext.Add("typedPass", pass);
        }

        [Then(@"The ceratin field text is change")]
        public void ThenTheCeratinFieldTextIsChange()
        {
            var email = _scenarioContext["typedEmail"].ToString();
            var pass = _scenarioContext["typedPass"].ToString();
            _user.ReadsFieldValue(LoginForm.EMIAL_FIELD).Should().Be(email);
            _user.ReadsFieldValue(LoginForm.PASSWORD_FIELD).Should().Be(pass);
        }


        [When(@"I log in ""(.*)"" and ""(.*)""")]
        public void WhenILogInAnd(string email, string pass)
        {
            _user.TypesInto(LoginForm.EMIAL_FIELD, email);
            _user.TypesInto(LoginForm.PASSWORD_FIELD, pass);
            _user.ClicksOn(LoginForm.LOGIN_BUTTON);
            _scenarioContext.Add("email", email);

        }

        [Then(@"I'm successfully logged in")]
        public void ThenIMSuccessfullyLoggedIn()
        {
            var email = _scenarioContext["email"].ToString();
            _user.ReadsTextFrom(MainMenu.LOGGED_IN_BUTTON).Should().Contain(email);
        }

        [When(@"I try to log in:")]
        public void WhenITryToLogIn(Table table)
        {
            var users = table.CreateSet<User>();
            foreach (var user in users)
            {
                _user.TypesInto(LoginForm.EMIAL_FIELD, user.Email);
                _user.TypesInto(LoginForm.PASSWORD_FIELD, user.Password);
                _user.ClicksOn(LoginForm.LOGIN_BUTTON);
            }
        }

        [Then(@"Error Message pops-up")]
        public void ThenErrorMessagePops_Up()
        {
            var errorMessage = "Invalid user or email";
            _user.ReadsTextFrom(LoginForm.ALERT_MESSAGE).Should().Contain(errorMessage);
        }

        [Then(@"User stays on login page")]
        public void ThenUserStaysOnLoginPage()
        {
            var pageTitle = "Please login Login:";
            _user.ReadsTextFrom(LoginForm.TITLE).Should().Be(pageTitle);
        }
    }
}
