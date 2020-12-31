namespace TravelManagerFE.Data.Models
{
    public class TripRequest
    {
        public string Title { get; set; }
        public TripType Type { get; set; }
        public string CreatorId { get; set; }
    }
}
