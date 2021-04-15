using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutApp.Data;

namespace WorkoutApp.Models
{
    public class WorkoutsDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }

        public virtual List<Ratings> Ratings { get; set; }

        public double AverageWorkoutScore { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
