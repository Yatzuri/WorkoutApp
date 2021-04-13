using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Models
{
    public class ExerciseDetail
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public int Sets { get; set; }


        public int Reps { get; set; }


        public string Level { get; set; }
    }
}
