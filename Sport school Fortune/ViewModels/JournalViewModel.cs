using Sport_school_Fortune.Models;
using System.Collections.Generic;

namespace Sport_school_Fortune.ViewModels
{
    public class JournalViewModel
    {
        public IEnumerable<Journal> allJournal { get; set; }
        public IEnumerable<Sportsman> allSportsman { get; set; }
        public IEnumerable<Sport> allSport { get; set; }
        public IEnumerable<Trainer> allTrainer { get; set; }

    }
}
