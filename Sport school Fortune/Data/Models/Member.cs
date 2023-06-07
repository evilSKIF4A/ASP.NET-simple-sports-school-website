using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sport_school_Fortune.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int sportsmanId { get; set; }
        public int activityId { get; set; }
        public int place { get; set; }
    }
}
