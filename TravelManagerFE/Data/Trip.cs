using System.Collections.Generic;

namespace TravelManagerFE.Data
{
    public class Trip
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public List<Destination> Destinations { get; set; }
    }
}