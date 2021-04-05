using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelManagerFE.Data.Models
{
    public class Comment
    {
        public Comment()
        {
            ChildComments = new List<Comment>();
        }

        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public Visit Visit { get; set; }

        public Review Review { get; set; }

        public User Creator { get; set; }

        public Comment ParentComment { get; set; }

        public List<Comment> ChildComments { get; set; }
    }
}
