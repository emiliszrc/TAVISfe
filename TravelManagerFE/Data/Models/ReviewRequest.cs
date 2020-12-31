using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE.Data.Models
{
    public class ReviewRequest
    {
        public string TripId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public string ApprovalStatus { get; set; }
    }
}
