using System.Collections.Generic;
using System.Linq;
using TravelManagerFE.Data.Models;

namespace TravelManagerFE.Data
{
    public class Trip
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public List<Visit> Visits { get; set; } = new List<Visit>();
        public string Type { get; set; }
        public string Cost { get; set; }
        public User Creator { get; set; }
        public Organisation Organisation { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public TripStatus TripStatus { get; set; }
    }

    public enum TripStatus
    {
        New,
        InReview,
        ReadyToFinalize,
        Final
    }
}