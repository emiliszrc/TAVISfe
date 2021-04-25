using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE.Data.Models
{
    public class Review
    {
        public Review()
        {
            Comments = new List<Comment>();
            Approvals = new List<Approval>();
        }

        public string Id { get; set; }

        public Trip Trip { get; set; }

        public User User { get; set; }

        public string Status { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Approval> Approvals { get; set; }

        public List<Reviewer> Reviewers { get; set; }

        public List<Warning> Warnings { get; set; }
    }

    public class Warning
    {
        public string WarningCode { get; set; }
        public string WarningText { get; set; }
        public bool IsBlocker { get; set; }
        public Visit Visit { get; set; }
    }

    public class Reviewer
    {
        public User User { get; set; }
        public Review Review { get; set; }
    }

    public class Approval
    {
        public User User { get; set; }
        public ApprovalStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public enum ApprovalStatus
    {
        Approved,
        Rejecting,
        Cancelled,
        NeedsWork
    }
}
