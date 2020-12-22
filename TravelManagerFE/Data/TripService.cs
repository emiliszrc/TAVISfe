using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

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

        public Trip AddDestinationToTrip(string tripId, Destination destination)
        {
            var destinationRequest = DestinationRequest.From(destination);

            var client = new RestClient($"https://localhost:44308/api/trips/{tripId}/Destinations");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(destinationRequest);

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
            request.AddJsonBody(trip.Destinations);

            var response = client.Execute(request);

            if (!response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                //throw new TripAdvisorApiException($"Could not retrieve information from TripAdvisor. Response code: {response.StatusCode}");
            }

            var tripResponse = JsonConvert.DeserializeObject<Trip>(response.Content);

            return tripResponse;
        }
    }
}
