using BasicSelenium.Models;
using BasicSelenium.Steps.Actions;
using BasicSelenium.UIComponents;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BasicSelenium.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private readonly BaseUserActions _user;
        private readonly ScenarioContext _scenarioContext;

        public RegisterSteps(BaseUserActions user, ScenarioContext scenarioContext)
        {
            this._user = user;
            this._scenarioContext = scenarioContext;
        }

        [Given(@"Register page is opened")]
        public void GivenRegisterPageIsOpened()
        {
            _user.OpensPage("register");
        }

        [When(@"I type into regiter fields ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void WhenITypeIntoRegiterFieldsAndAndAndAndAnd(string firstName, string sirName,
                                                              string email, string pass, 
                                                              string country, string city)
        {
            TypeInFields(firstName, sirName,email, pass, country, city);
            AddTypedValueToScenarioContext(firstName, sirName, email,
                                           pass, country, city);
        }

        [Then(@"The certain register field text is change")]
        public void ThenTheCeratinRegisterFieldTextIsChange()
        {
            var firstName = _scenarioContext["firstName"].ToString();
            var sirName = _scenarioContext["sirName"].ToString();
            var email = _scenarioContext["email"].ToString();
            var pass = _scenarioContext["pass"].ToString();
            var country = _scenarioContext["country"].ToString();
            var city = _scenarioContext["city"].ToString();

            _user.ReadsFieldValue(RegisterForm.FIRST_NAME_FIELD).Should().Be(firstName);
            _user.ReadsFieldValue(RegisterForm.SIR_NAME_FIELD).Should().Be(sirName);
            _user.ReadsFieldValue(RegisterForm.EMAiL_FIELD).Should().Be(email);
            _user.ReadsFieldValue(RegisterForm.PASSWORD_FIELD).Should().Be(pass);
            _user.ReadsFieldValue(RegisterForm.COUNTRY_FIELD).Should().Be(country);
            _user.ReadsFieldValue(RegisterForm.CITY_FIELD).Should().Be(city);
        }


        [When(@"I select Mr")]
        public void WhenISelectMr()
        {
            _user.ClicksOn(RegisterForm.MR_RADIO_BUTTON);
        }

        [Then(@"Mr has checked attribute")]
        public void ThenMrGetCheckedAttribute()
        {
            var mrButton = _user.Find(RegisterForm.MR_RADIO_BUTTON);
            var mrsButton = _user.Find(RegisterForm.MRS_RADIO_BUTTON);
            mrButton.GetAttribute("checked").Should().Be("true");
            mrsButton.GetAttribute("checked").Should().BeNull();
        }

        [When(@"I select Mrs")]
        public void WhenISelectMrs()
        {
            _user.ClicksOn(RegisterForm.MRS_RADIO_BUTTON);
        }

        [Then(@"Mrs has checked attribute")]
        public void ThenMrsGetCheckedAttribute()
        {
            var mrsButton = _user.Find(RegisterForm.MRS_RADIO_BUTTON);
            var mrButton = _user.Find(RegisterForm.MR_RADIO_BUTTON);
            mrsButton.GetAttribute("checked").Should().Be("true");
            mrButton.GetAttribute("checked").Should().BeNull();
        }


        [When(@"I select TOS")]
        public void WhenISelectTOS()
        {
            _user.ClicksOn(RegisterForm.TERMS_OF_SERVICE_CHECKBOX); 
        }

        [Then(@"TOS has checked attribute")]
        public void ThenTOSHasCheckedAttribute()
        {
            var checkbox = _user.Find(RegisterForm.TERMS_OF_SERVICE_CHECKBOX);
            checkbox.GetAttribute("checked").Should().Be("true");
        }

        [When(@"I unselect Mrs")]
        public void WhenIUnselectMrs()
        {
            _user.ClicksOn(RegisterForm.TERMS_OF_SERVICE_CHECKBOX);
            _user.ClicksOn(RegisterForm.TERMS_OF_SERVICE_CHECKBOX);
        }

        [Then(@"Mrs hasn't checked attribute")]
        public void ThenMrsHasnTCheckedAttribute()
        {
            var checkbox = _user.Find(RegisterForm.TERMS_OF_SERVICE_CHECKBOX);
            checkbox.GetAttribute("checked").Should().BeNull();
        }


        [When(@"I try to register with valid data ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void WhenITryToRegisterWithValidDataAndAndAndAndAnd(string firstName, string sirName, 
                                                                   string email, string pass,
                                                                   string country, string city)
        {
            TypeInFields(firstName, sirName, email, pass, country, city);
            _user.ClicksOn(RegisterForm.TERMS_OF_SERVICE_CHECKBOX);
            _user.ClicksOn(RegisterForm.REGISTER_BUTTON);
            _scenarioContext.Add("regUserEmail", email);
        }

        [Then(@"I registered successfully")]
        public void ThenIRegisteredSuccessfully()
        {
            var email = _scenarioContext["regUserEmail"].ToString();
            _user.ReadsTextFrom(MainMenu.LOGGED_IN_BUTTON).Should().Contain(email);
        }

        [When(@"I try to register with empty field")]
        public void WhenITryToRegisterWithEmptyField(Table table)
        {
            var users = table.CreateSet<User>();
            foreach (var user in users)
            {
                TypeInFields(user.FirstName, user.SirName, user.Email,
                             user.Password, user.Country, user.City);
                _user.ClicksOn(RegisterForm.TERMS_OF_SERVICE_CHECKBOX);
                _user.ClicksOn(RegisterForm.REGISTER_BUTTON);
            }
        }

        [Then(@"I stay on register page")]
        public void ThenIStayOnRegisterPage()
        {
            var pageTitle = "Register for our School of Automation";
            _user.ReadsTextFrom(RegisterForm.TITLE).Should().Be(pageTitle);
        }

        [When(@"I try to register with already used email ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void WhenITryToRegisterWithAlreadyUsedEmailAndAndAndAndAnd(string firstName, string sirName,
                                                                          string email, string pass,
                                                                          string country, string city)
        {
            TypeInFields(firstName, sirName, email, pass, country, city);
            _user.ClicksOn(RegisterForm.TERMS_OF_SERVICE_CHECKBOX);
            _user.ClicksOn(RegisterForm.REGISTER_BUTTON);
        }


        [Then(@"Error message pops-up")]
        public void ThenErrorMessagePops_Up()
        {
            _user.CanSee(RegisterForm.ALERT_MESSAGE).Should().BeTrue();
        }


        private void AddTypedValueToScenarioContext(string firstName, string sirName, string email, string pass, string country, string city)
        {
            _scenarioContext.Add("firstName", firstName);
            _scenarioContext.Add("sirName", sirName);
            _scenarioContext.Add("email", email);
            _scenarioContext.Add("pass", pass);
            _scenarioContext.Add("country", country);
            _scenarioContext.Add("city", city);
        }

        private void TypeInFields(string firstName, string sirName, string email, string pass, string country, string city)
        {
            _user.TypesInto(RegisterForm.FIRST_NAME_FIELD, firstName);
            _user.TypesInto(RegisterForm.SIR_NAME_FIELD, sirName);
            _user.TypesInto(RegisterForm.EMAiL_FIELD, email);
            _user.TypesInto(RegisterForm.PASSWORD_FIELD, pass);
            _user.TypesInto(RegisterForm.COUNTRY_FIELD, country);
            _user.TypesInto(RegisterForm.CITY_FIELD, city);
        }
    }
}