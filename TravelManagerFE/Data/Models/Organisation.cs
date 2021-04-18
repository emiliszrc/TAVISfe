using System.Collections.Generic;

namespace TravelManagerFE.Data.Models
{
    public class Organisation
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Contract> Contracts { get; set; }
        public int RequiredReviewerCount { get; set; }
    }
}