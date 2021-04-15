using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutApp.Data;

namespace WorkoutApp.Models
{
    public class RatingsDetail
    {
        public int Id { get; set; }

        [ForeignKey("Workouts")]
        public int WorkoutPlanId { get; set; }
        public virtual Workouts Workouts { get; set; }

        
        public double ExertionScore { get; set; }

        
        public double EnjoymentScore { get; set; }

        
        public double HeartrateScore { get; set; }
    }
}
