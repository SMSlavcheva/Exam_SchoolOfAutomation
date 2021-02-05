using BasicSelenium.Models;
using RestSharp;
using Newtonsoft.Json;
using static BasicSelenium.Utils.ConfigurationProperties;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BasicSelenium.Utils
{
    public class RestClient
    {
        private RestSharp.RestClient GetRestClient()
        {
            return new RestSharp.RestClient(GetConfigurationProperty().Named(Properties.REST_HOST));
        }

        public RestRequest GetGETRestRequest(string path)
        {
            return new RestRequest(path, Method.GET);
        }

        public RestRequest GetDELETERestRequest(string path)
        {
            return new RestRequest(path, Method.DELETE);
        }

        public RestRequest GetPOSTRestRequest(string path, User user)
        {
            var request = new RestRequest(path, Method.POST);
            request.RequestFormat = DataFormat.Json;

            object preparedObject = PrapareObjectForSerialization(user);

            request.AddJsonBody(preparedObject);

            return request;
        }


        public RestRequest GetPUTRestRequest(string path)
        {
            return new RestRequest(path, Method.PUT);
        }

        public IRestResponse GetGETResponse(string path)
        {
            return GetRestClient().Execute(GetGETRestRequest(path));
        }

        public IRestResponse GetPOSTResponse(string path, User user)
        {
            var result = GetRestClient().Execute(GetPOSTRestRequest(path, user));
            return result;
        }

        public string GetGETResponseText(string path)
        {
            return GetGETResponse(path).Content;
        }

        public string GetGETResponseCode(string path)
        {
            return GetGETResponse(path).StatusCode.ToString();
        }

        public string GetPOSTResponseText(string path, User user)
        {
            var result = GetPOSTResponse(path, user);
            return result.Content;
        }

        public string GetPOSTResponseCode(string path, User user)
        {
            var result = GetPOSTResponse(path, user);
            return result.StatusCode.ToString();
        }

        public User DeserializeUser(string content)
        {
            return JsonConvert.DeserializeObject<User>(content);
        }

        public List<User> DeserializeUserArray(string content)
        {
            return JsonConvert.DeserializeObject<List<User>>(content);
        }

        private object PrapareObjectForSerialization(User user)
        {
            return new
            {
                title = user.Title,
                first_name = user.FirstName,
                sir_name = user.SirName,
                country = user.Country,
                city = user.City,
                email = user.Email,
                password = user.Password,
                is_admin = user.IsAdmin,
            };
        }
    }
}

