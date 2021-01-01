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
        public List<Trip> GetTrips()
        {
            var client = new RestClient($"https://localhost:44308/api/trips/all");
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
            var client = new RestClient($"https://localhost:44308/api/trips/{id}");
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
            var client = new RestClient($"https://localhost:44308/api/trips/{visitRequest.TripId}/Visits");
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
            var client = new RestClient($"https://localhost:44308/api/trips");
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
            var client = new RestClient($"https://localhost:44308/api/trips/{trip.Id}/Destinations/Reorder");
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
            var client = new RestClient($"https://localhost:44308/api/Trips/{reviewRequest.TripId}/Reviews");
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

        public Review PostComment(string reviewId, string tripId, CommentRequest commentRequest)
        {
            var client = new RestClient($"https://localhost:44308/api/Trips/{tripId}/Reviews/{reviewId}/Comments");
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

        public List<Review> GetReviewBy(string id, string currentUserId)
        {
            var client = new RestClient($"https://localhost:44308/api/Trips/{id}/Reviews/ByUser");
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

        public List<Review> GetReviewBy(string id)
        {
            var client = new RestClient($"https://localhost:44308/api/Trips/{id}/Reviews/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<List<Review>>(response.Content);

            return reviewResponse;
        }

        public Location AddLocation(string tripId, Location location)
        {
            var client = new RestClient($"https://localhost:44308/api/trips/Locations");
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
    }
}
