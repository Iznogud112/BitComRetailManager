﻿using BitComDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BitComDesktopUI.Library.API
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient;
        private ILoggedInUserModel _loggedUserModel;

        public APIHelper(ILoggedInUserModel loggedInUser)
        {
            InitializeClient();
            _loggedUserModel = loggedInUser;
        }
        
        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            //Creates new HttpClient used for the lifetime of WPF instance we are using, one open
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string userName, string password)
        {
            //Form URL encode content and posts to the token 
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password)
            });

            //When is successful pass back the response information what you authenticate and authenticated user
            using (HttpResponseMessage response = await apiClient.PostAsync("/token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task GetLoggedInUserInfo(string token)
        {
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //For every call we make default request headers we want too add the autorization bearer token
            apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");

            using (HttpResponseMessage response = await apiClient.GetAsync("/api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggedUserModel.Id = result.Id;
                    _loggedUserModel.FirstName = result.FirstName;
                    _loggedUserModel.LastName = result.LastName;
                    _loggedUserModel.EmailAdress = result.EmailAdress;
                    _loggedUserModel.CreatedDate = result.CreatedDate;
                    _loggedUserModel.Token = token;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
