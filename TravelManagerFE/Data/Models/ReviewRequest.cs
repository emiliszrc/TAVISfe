using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE.Data.Models
{
    public class ReviewRequest
    {
        public string TripId { get; set; }
        public List<string> Reviewers { get; set; }
        public bool IgnoreWarnings { get; set; }
    }
}
