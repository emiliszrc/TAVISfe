using System.Collections.Generic;
using TravelManagerFE.Data.Models;

namespace TravelManagerFE.Data
{
    public class Trip
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public List<Visit> Visits { get; set; }
        public string Type { get; set; }
        public string Cost { get; set; }
        public User Creator { get; set; }
        public List<Review> Reviews { get; set; }
    }
}