namespace TravelManagerFE.Data
{
    public class LocationRequest
    {
        public string Title { get; set; }

        public string Type { get; set; }

        public string LocationId { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }

        public static LocationRequest From(Location location)
        {
            return new LocationRequest
            {
                Title = location.Title,
                Type = location.Type,
                LocationId = location.LocationId,
                Address = location.Address,
                Latitude = location.Latitude,
                Longtitude = location.Longtitude
            };
        }
    }
}