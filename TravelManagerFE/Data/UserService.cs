using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace TravelManagerFE.Data
{
    public class UserService
    {
        //private const string baseUrl = "https://lkosapi.azurewebsites.net/api/";
        private const string baseUrl = "https://localhost:44308/api/";
        public async Task<User> Login(string username, string password)
        {
            var client = new RestClient(baseUrl+$"users/{username}/{password}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddQueryParameter(username, username);
            request.AddQueryParameter(password, password);

            var response = await client.ExecuteAsync(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var user = JsonConvert.DeserializeObject<User>(response.Content);
            return user;
        }

        public async void CreateUser(string username, string password, string name, string surname)
        {
            var user = new UserRequest(username, password, name, surname);

            var client = new RestClient(baseUrl + $"user");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);

            var response = await client.ExecuteAsync(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            //var user = JsonConvert.DeserializeObject<User>(response.Content);
        }

        public async Task<User> GetByUsername(string username)
        {
            var client = new RestClient(baseUrl + $"user");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddQueryParameter("username", username);

            var response = await client.ExecuteAsync(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var user = JsonConvert.DeserializeObject<User>(response.Content);
            //var user = new User(username, password, "0");
            return user;
        }
    }

    public class UserRequest
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public UserRequest(string username, string password, string name, string surname)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
        }
    }
}
