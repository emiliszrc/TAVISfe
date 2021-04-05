using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TravelManagerFE.Data.Models;

namespace TravelManagerFE.Data
{
    public class TripService
    {
        //private const string baseUrl = "https://lkosapi.azurewebsites.net/api/";
        private const string baseUrl = "https://localhost:44308/api/";
        public List<Trip> GetTrips()
        {
            var client = new RestClient(baseUrl + $"trips/all");
            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var trips = JsonConvert.DeserializeObject<List<Trip>>(response.Content);

            return trips;
        }

        public Trip GetTrip(string id)
        {
            var client = new RestClient(baseUrl+ $"trips/{id}");
            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var trip = JsonConvert.DeserializeObject<Trip>(response.Content);

            return trip;
        }

        public Trip AddDestinationToTrip(VisitRequest visitRequest)
        {
            var client = new RestClient(baseUrl + $"trips/{visitRequest.TripId}/Visits");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(visitRequest);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var trip = JsonConvert.DeserializeObject<Trip>(response.Content);

            return trip;
        }

        public Trip CreateTrip(TripRequest trip)
        {
            var client = new RestClient(baseUrl + $"trips");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(trip);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var tripResponse = JsonConvert.DeserializeObject<Trip>(response.Content);

            return tripResponse;
        }

        public Trip ReorderTripDestinations(Trip trip)
        {
            var client = new RestClient(baseUrl + $"trips/{trip.Id}/Destinations/Reorder");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(trip.Visits);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var tripResponse = JsonConvert.DeserializeObject<Trip>(response.Content);

            return tripResponse;
        }

        public Review CreateReview(ReviewRequest reviewRequest)
        {
            var client = new RestClient(baseUrl + $"Reviews");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(reviewRequest);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Review>(response.Content);

            return reviewResponse;
        }

        public Review PostComment(string reviewId, CommentRequest commentRequest)
        {
            var client = new RestClient(baseUrl + $"Reviews/{reviewId}/Comments");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(commentRequest);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Review>(response.Content);

            return reviewResponse;
        }

        public List<Review> GetReviewBy(string reviewId, string currentUserId)
        {
            var client = new RestClient(baseUrl + $"Trips/{reviewId}/Reviews/ByUser");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddQueryParameter("userId", currentUserId);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<List<Review>>(response.Content);

            return reviewResponse;
        }

        public Review GetReviewBy(string reviewId)
        {
            var client = new RestClient(baseUrl + $"Reviews/{reviewId}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Review>(response.Content);

            return reviewResponse;
        }

        public Validity GetTripValidity(string tripId)
        {
            var client = new RestClient(baseUrl + $"Trips/Validate/{tripId}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Validity>(response.Content);

            return reviewResponse;
        }

        public Location AddLocation(string tripId, Location location)
        {
            var client = new RestClient(baseUrl + $"trips/Locations");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(location);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var locationResponse = JsonConvert.DeserializeObject<Location>(response.Content);

            return locationResponse;
        }

        public void RemoveVisit(string tripId, string contextId)
        {
            var client = new RestClient(baseUrl + $"trips/{tripId}/Visits/{contextId}");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var locationResponse = JsonConvert.DeserializeObject<Location>(response.Content);
        }

        public Review AddReviewStatus(ReviewStatusRequest reviewRequest)
        {
            var client = new RestClient(baseUrl + $"Reviews/{reviewRequest.ReviewId}/Status");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(reviewRequest);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Review>(response.Content);

            return reviewResponse;
        }

        public List<Review> GetReviewsByUserId(string userId)
        {
            var client = new RestClient(baseUrl + $"Reviews/by-user/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddQueryParameter("userId", userId);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<List<Review>>(response.Content);

            return reviewResponse;
        }

        public class Validity
        {
            public IEnumerable<Reason> Reasons { get; set; }

            public bool IsValid { get; set; }
        }

        public class Reason
        {
            public string Code { get; set; }

            public string Text { get; set; }

            public string VisitId { get; set; }

            public bool IsBlocker { get; set; }
        }

        public Visit UpdateVisit(string id, VisitRequest visitRequest)
        {
            var client = new RestClient(baseUrl + $"trips/Visits/{id}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(visitRequest);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var visit = JsonConvert.DeserializeObject<Visit>(response.Content);

            return visit;
        }

        public Visit GetVisitById(string id)
        {
            var client = new RestClient(baseUrl + $"trips/Visits/{id}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Visit>(response.Content);

            return reviewResponse;
        }
    }
}
