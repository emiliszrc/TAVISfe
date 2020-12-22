namespace TravelManagerFE.Data
{
    public class DestinationRequest
    {
        public string Title { get; set; }

        public string Type { get; set; }

        public string LocationId { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }

        public static DestinationRequest From(Destination destination)
        {
            return new DestinationRequest
            {
                Title = destination.Title,
                Type = destination.Type,
                LocationId = destination.LocationId,
                Address = destination.Address,
                Latitude = destination.Latitude,
                Longtitude = destination.Longtitude
            };
        }
    }
}