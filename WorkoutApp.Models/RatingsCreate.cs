using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Models
{
    public class RatingsCreate
    {
        public double ExertionScore { get; set; }
        public double EnjoymentScore { get; set; }
        public double HeartrateScore { get; set; }
        public int WorkoutPlanId { get; set; }

    }
}
