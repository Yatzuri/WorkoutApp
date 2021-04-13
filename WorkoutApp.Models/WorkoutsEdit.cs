using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Models
{
    public class WorkoutsEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsStarred { get; set; }
        public string RatingsList { get; set; }
    }
}
