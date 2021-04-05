using System.Collections.Generic;
using TravelManagerFE.Data.Models;

namespace TravelManagerFE.Data
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}