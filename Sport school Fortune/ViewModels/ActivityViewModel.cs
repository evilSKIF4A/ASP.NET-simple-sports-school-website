using Sport_school_Fortune.Models;
using System.Collections.Generic;

namespace Sport_school_Fortune.ViewModels
{
    public class ActivityViewModel
    {
        public IEnumerable<Activity> allActivity { get; set; }
        public IEnumerable<Sport> allSport { get; set; }
    }
}
