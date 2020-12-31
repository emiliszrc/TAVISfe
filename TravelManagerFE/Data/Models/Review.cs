using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE.Data.Models
{
    public class Review
    {
        public string Id { get; set; }

        public Trip Trip { get; set; }

        public User User { get; set; }

        public string ApprovalStatus { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
