using BasicSelenium.Models;
using BasicSelenium.Steps.Actions;
using BasicSelenium.UIComponents;

using FluentAssertions;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BasicSelenium.Steps
{
    [Binding]
    public class UpdateProfileSteps
    {
        private readonly BaseUserActions _user;
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginSteps _loginSteps;

        public UpdateProfileSteps(BaseUserActions user, ScenarioContext scenarioContext)
        {
            _user = user;
            _scenarioContext = scenarioContext;
            _loginSteps = new LoginSteps(user, scenarioContext);
        }

        [Given(@"Update profile page is opened")]
        public void GivenUpdateProfilePageIsOpened()
        {
            _user.StartsApplication();
            _loginSteps.WhenILogInAnd("DoR@gmail.com", "Bsdfd3");
            _user.OpensPage("profile");
        }

        [When(@"I type into fields ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void WhenITypeIntoFieldsAndAndAnd(string firstName, string sirName, string country, string city)
        {
            TypeInFields(firstName, sirName, country, city);
            AddTypedValueToScenarioContext(firstName, sirName, country, city);
        }


        [Then(@"The certain field text is change")]
        public void ThenTheCertainFieldTextIsChange()
        {
            var firstName = _scenarioContext["firstName"].ToString();
            var sirName = _scenarioContext["sirName"].ToString();
            var country = _scenarioContext["country"].ToString();
            var city = _scenarioContext["city"].ToString();

            _user.ReadsFieldValue(UpdateProfileForm.FIRST_NAME_FIELD).Should().Be(firstName);
            _user.ReadsFieldValue(UpdateProfileForm.SIR_NAME_FIELD).Should().Be(sirName);
            _user.ReadsFieldValue(UpdateProfileForm.COUNTRY_FIELD).Should().Be(country);
            _user.ReadsFieldValue(UpdateProfileForm.CITY_FIELD).Should().Be(city);
        }

        [When(@"I try to update")]
        public void WhenITryToUpdate(Table table)
        {
            var users = table.CreateSet<User>();

            foreach (var user in users)
            {
                TypeInFields(user.FirstName, user.SirName, user.Country, user.City);
            }
            var pageTitle = _user.ReadsTextFrom(UpdateProfileForm.TITLE);
            _scenarioContext.Add("titleBeforeClick", pageTitle);
            _user.ClicksOn(UpdateProfileForm.UPDATE_BUTTON);
        }

        [Then(@"The page title doesn't change")]
        public void ThenThePageTitleDoesnTChange()
        {
            var titleBeforeClick = _scenarioContext["titleBeforeClick"].ToString();
            _user.ReadsTextFrom(UpdateProfileForm.TITLE).Should().Be(titleBeforeClick);
        }

        [Then(@"The page title is changed")]
        public void ThenThePageTitleIsChanged()
        {
            var titleBeforeClick = _scenarioContext["titleBeforeClick"].ToString();
            _user.ReadsTextFrom(UpdateProfileForm.TITLE).Should().NotBe(titleBeforeClick);
        }

        [When(@"I select UpdateProfile Mr")]
        public void WhenISelectUpdateProfileMr()
        {
            _user.ClicksOn(UpdateProfileForm.MR_RADIO_BUTTON);
        }

        [Then(@"UpdateProfile Mr has checked attribute")]
        public void ThenUpdateProfilMrHasCheckedAttribute()
        {
            var mrRadioBtn = _user.Find(UpdateProfileForm.MR_RADIO_BUTTON);
            var mrsRadioBtn = _user.Find(UpdateProfileForm.MRS_RADIO_BUTTON);
            mrRadioBtn.GetAttribute("checked").Should().Be("true");
            mrsRadioBtn.GetAttribute("checked").Should().BeNull();
        }

        [When(@"I select UpdateProfile Mrs")]
        public void WhenISelectUpdateProfileMrs()
        {
            _user.ClicksOn(UpdateProfileForm.MRS_RADIO_BUTTON);
        }

        [Then(@"UpdateProfile Mrs has checked attribute")]
        public void ThenUpdateProfileMrsHasCheckedAttribute()
        {
            var mrRadioBtn = _user.Find(UpdateProfileForm.MR_RADIO_BUTTON);
            var mrsRadioBtn = _user.Find(UpdateProfileForm.MRS_RADIO_BUTTON);
            mrRadioBtn.GetAttribute("checked").Should().BeNull();
            mrsRadioBtn.GetAttribute("checked").Should().Be("true");
        }

        private void TypeInFields(string firstName, string sirName, string country, string city)
        {
            _user.TypesInto(UpdateProfileForm.FIRST_NAME_FIELD, firstName);
            _user.TypesInto(UpdateProfileForm.SIR_NAME_FIELD, sirName);
            _user.TypesInto(UpdateProfileForm.COUNTRY_FIELD, country);
            _user.TypesInto(UpdateProfileForm.CITY_FIELD, city);
        }

        private void AddTypedValueToScenarioContext(string firstName, string sirName, string country, string city)
        {
            _scenarioContext.Add("firstName", firstName);
            _scenarioContext.Add("sirName", sirName);
            _scenarioContext.Add("country", country);
            _scenarioContext.Add("city", city);
        }
    }
}
