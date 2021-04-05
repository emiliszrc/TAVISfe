using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE.Data.Models
{
    public class Invite
    {
        public string Id { get; set; }
        public User User { get; set; }
        public Organisation Organisation { get; set; }
        public InviteStatus Status { get; set; }
    }

    public enum InviteStatus
    {
        New,
        Accepted,
        Rejected
    }
}
