using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sport_school_Fortune.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int sportId { get; set; }
        public string date { get; set; }
        public string name { get; set; }
    }
}
