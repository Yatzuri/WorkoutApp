using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Data
{
    public class Ratings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Workout")]
        public int WorkoutPlanId { get; set; }

        [Required]
        public double ExertionScore { get; set; }

        [Required]
        public double EnjoymentScore { get; set; }

        [Required]
        public double HeartrateScore { get; set; }

        public double AverageScore
        {
            get
            {
                return (ExertionScore * 2 + EnjoymentScore + HeartrateScore)  / 4;
            }
        }
    }
}
