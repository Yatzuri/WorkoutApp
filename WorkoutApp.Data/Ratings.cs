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
        public int ExertionScore { get; set; }

        [Required]
        public int EnjoymentScore { get; set; }

        [Required]
        public int HeartrateScore { get; set; }
    }
}
