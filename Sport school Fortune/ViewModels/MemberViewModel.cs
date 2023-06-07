using Sport_school_Fortune.Models;
using System.Collections.Generic;

namespace Sport_school_Fortune.ViewModels
{
    public class MemberViewModel
    {
        public IEnumerable<Member> allMember { get; set; }
        public IEnumerable<Sportsman> allSportsman { get; set; }
        public IEnumerable<Activity> allActivity { get; set; }
        public IEnumerable<Sport> allSport { get; set; }
    }
}
