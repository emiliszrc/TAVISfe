﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE.Data.Models
{
    public class Visit
    {
        public Visit()
        {
            Location = new Location();
        }
        public string Id { get; set; }
        public string VisitationIndex { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public Location Location { get; set; }
        public Trip Trip { get; set; }
    }
}
