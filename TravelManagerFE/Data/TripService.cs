using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using TravelManagerFE.Data.Models;
using TravelManagerFE.Pages;

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

        public List<Trip> GetUserTrips(string userId)
        {
            var client = new RestClient(baseUrl + $"trips/createdByUser/{userId}");
            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var trips = JsonConvert.DeserializeObject<List<Trip>>(response.Content);

            return trips;
        }

        public List<Trip> GetOrganisationTrips(string organisationId)
        {
            var client = new RestClient(baseUrl + $"trips/createdByOrganisation/{organisationId}");
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

        public Review GetCurrentReviewByTripId(string tripId)
        {
            var client = new RestClient(baseUrl + $"reviews/by-trip");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddQueryParameter("tripId", tripId);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Review>(response.Content);

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
            var client = new RestClient(baseUrl + $"Reviews/by-user/forApproval");
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

        public List<Review> GetAlreadyApprovedReviewsByUserId(string userId)
        {
            var client = new RestClient(baseUrl + $"Reviews/by-user/alreadyApproved");
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

        public List<Review> GetClosedReviewsByUserId(string userId)
        {
            var client = new RestClient(baseUrl + $"Reviews/by-user/closed");
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

        public List<Review> GetReviewsByCreatorId(string userId)
        {
            var client = new RestClient(baseUrl + $"Reviews/by-creator/forApproval");
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

        public List<Review> GetAlreadyApprovedReviewsByCreatorId(string userId)
        {
            var client = new RestClient(baseUrl + $"Reviews/by-creator/alreadyApproved");
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

        public List<Review> GetClosedReviewsByCreatorId(string userId)
        {
            var client = new RestClient(baseUrl + $"Reviews/by-creator/closed");
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

        public void DeleteTrip(string tripId)
        {
            var client = new RestClient(baseUrl + $"trips/{tripId}");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }
        }

        public List<Reviewer> GetReviewersForTripId(string tripId)
        {
            var client = new RestClient(baseUrl + $"trips/{tripId}/Reviewers");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<List<Reviewer>>(response.Content);

            return reviewResponse;
        }

        public List<Trip> GetFinalTripsForUser(string currentUserId)
        {
            var client = new RestClient(baseUrl + $"trips/final/{currentUserId}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<List<Trip>>(response.Content);

            return reviewResponse;
        }

        public List<ClientResponse> GetParticipantsForTrip(string id)
        {
            var client = new RestClient(baseUrl + $"clients/forTrip/{id}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<List<ClientResponse>>(response.Content);

            return reviewResponse;
        }

        public List<ClientResponse> InviteParticipant(ParticipationRequest participationRequest)
        {
            var client = new RestClient(baseUrl + $"clients/invite");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(participationRequest);

            var response = client.Execute(request);
            var reviewResponse = new List<ClientResponse>();
            if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");

                reviewResponse = JsonConvert.DeserializeObject<List<ClientResponse>>(response.Content);
            }


            return reviewResponse;
        }

        public bool SendEmailByUserId(string participant, string trip, bool resend)
        {
            var client = new RestClient(baseUrl + $"clients/sendInviteEmail/byClient/{participant}/{trip}/{resend}");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                return false;
            }

            return true;
        }

        public Trip ReuseTrip(TripReuse.TripReuseRequest reuseRequest)
        {
            var client = new RestClient(baseUrl + $"trips/{reuseRequest.ReusingTripId}/Reuse");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(reuseRequest);

            var response = client.Execute(request);

            if(!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Trip>(response.Content);

            return reviewResponse;
        }

        public Trip FinalizeTrip(string tripId, string userId)
        {
            var client = new RestClient(baseUrl + $"trips/{tripId}/Finalize");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddQueryParameter("userId", userId);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var reviewResponse = JsonConvert.DeserializeObject<Trip>(response.Content);

            return reviewResponse;
        }
    }

    public class Client
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string DefaultPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ClientResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string DefaultPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Notified { get; set; }
    }
}
