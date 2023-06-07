using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sport_school_Fortune.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public int sportsmanId  { get; set; }
        public int sportId { get; set; }
        public int trainerId { get; set; }
    }
}
