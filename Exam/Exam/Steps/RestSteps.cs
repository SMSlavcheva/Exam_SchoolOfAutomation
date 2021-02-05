using BasicSelenium.Models;
using BasicSelenium.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static BasicSelenium.Utils.ConfigurationProperties;

namespace BasicSelenium.Steps
{
    [Binding]
    public class RestSteps
    {
        private readonly RestClient _restClient;
        private readonly ScenarioContext _scenarioContext;

        public RestSteps(RestClient restClient, ScenarioContext scenarioContext)
        {
            _restClient = restClient;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I GET Users list via the corresponding endpoint")]
        public void IGETUsersList()
        {
            string response = _restClient.GetGETResponseText(GetConfigurationProperty().Named(Properties.REST_USERS_ENDPOINT));

            List<User> deserializedArrayResponse = _restClient.DeserializeUserArray(response);
        }

        [Given(@"I make a GET request for user with id (.*)")]
        public void GivenIMakeAGETRequestForUserWithId(int id)
        {
            string response = _restClient.GetGETResponseText(GetConfigurationProperty().Named(Properties.REST_USERS_ENDPOINT) + "/" + id);

            User deserializedArrayResponse = _restClient.DeserializeUser(response);
            _restClient.DeserializeUser(response);
        }

        [Then(@"I should see status message (.*)")]
        public void ThenIShouldSeeStatusCode(string statusMessage)
        {
            Assert.AreEqual(statusMessage, _restClient.GetGETResponseCode(GetConfigurationProperty().Named(Properties.REST_USERS_ENDPOINT)));
        }

        [Given(@"I log in via the corresponding endpoint")]
        public void GivenILogInViaTheCorrespondingEndpoint()
        {
            _restClient.GetGETResponseText(GetConfigurationProperty().Named(Properties.REST_LOGIN_ENDPOINT));
        }

        [When(@"I login user with:")]
        public void WhenILoginUserWith(Table table)
        {
            var user = table.CreateInstance<User>();

            var responseCode = _restClient.GetPOSTResponseCode(GetConfigurationProperty().Named(Properties.REST_LOGIN_ENDPOINT), user);
            _scenarioContext.Add("postResponseLogin", responseCode);
        }


        [Then(@"I should see login status message (.*)")]
        public void ThenIShouldSeeLoginStatusMessage(string statusMessage)
        {
            var result = _scenarioContext["postResponseLogin"].ToString();

            Assert.AreEqual(statusMessage, result);
        }

        [Given(@"I POST User via the corresponding endpoint")]
        public void GivenIPOSTUserViaTheCorrespondingEndpoint()
        {
            _restClient.GetGETResponseText(GetConfigurationProperty().Named(Properties.REST_USERS_ENDPOINT));
        }

        [When(@"I create user with:")]
        public void WhenICreateUserWith(Table table)
        {
            var user = table.CreateInstance<User>();
            
            string responseCode = _restClient.GetPOSTResponseCode(GetConfigurationProperty().Named(Properties.REST_USERS_ENDPOINT), user);
            _scenarioContext.Add("postResponseCreate", responseCode);
        }

        [Then(@"I should see create status message (.*)")]
        public void ThenIShouldSeeCreateStatusMessage(string statusMessage)
        {
            Assert.AreEqual(statusMessage, _scenarioContext["postResponseCreate"].ToString());
        }
    }
}
