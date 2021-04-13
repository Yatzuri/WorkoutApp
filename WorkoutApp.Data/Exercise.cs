using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Data
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Workout")]
        public int WorkoutPlanId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Sets { get; set; }

        [Required]
        public int Reps { get; set; }
    }
}
