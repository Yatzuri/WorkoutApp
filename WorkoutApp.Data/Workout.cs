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

        
        public virtual List<Ratings> Ratings { get; set; }
        
        public double Rating
        {
            get
            {
                double totalAverageRating = 0;
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.AverageScore;
                }
                return (Ratings.Count > 0)
                    ?
                        totalAverageRating / Ratings.Count
                    :
                        0;
            }
        }

        public double AverageWorkoutScore
        {
            get
            {
                IEnumerable<double> scores = Ratings.Select(r => r.ExertionScore);
                double totalExertionScores = scores.Sum();

                return Ratings.Count > 0 ? totalExertionScores / Ratings.Count : 0;
            }
        }



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
