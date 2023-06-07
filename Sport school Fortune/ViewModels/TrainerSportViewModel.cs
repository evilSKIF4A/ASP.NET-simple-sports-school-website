using Sport_school_Fortune.Models;
using System.Collections.Generic;

namespace Sport_school_Fortune.ViewModels
{
    public class TrainerSportViewModel
    {
        public IEnumerable<Trainer> allTrainer { get; set; }
        public IEnumerable<Sport> allSport { get; set; }
    }
}
