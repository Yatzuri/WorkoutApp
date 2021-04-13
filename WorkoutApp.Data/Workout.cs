using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Data
{
    public class Workouts
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string RatingsList { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int WorkoutLength { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Exercise { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
