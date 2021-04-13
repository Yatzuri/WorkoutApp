using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Models
{
    public class WorkoutsListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [UIHint("Starred")]
        [Display(Name = "Bookmark")]
        public bool IsStarred { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
