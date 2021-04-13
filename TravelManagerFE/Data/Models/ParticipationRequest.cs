using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE.Data.Models
{
    public class ParticipationRequest
    {
        public string Email { get; set; }
        public string TripId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
