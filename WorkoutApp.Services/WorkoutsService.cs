using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutApp.Data;
using WorkoutApp.Models;

namespace WorkoutApp.Services
{
    public class WorkoutsService
    {
        private readonly Guid _userId;

        public WorkoutsService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorkout(WorkoutsCreate model)
        {
            var entity =
                new Workouts()
                {
                    UserId = _userId,
                    Name = model.Name,
                    RatingsList = model.RatingsList,
                    CreatedUtc = DateTimeOffset.Now,
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Workouts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkoutsListItem> GetWorkouts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Workouts
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new WorkoutsListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public WorkoutsDetail GetWorkoutById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workouts
                    .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new WorkoutsDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        RatingsList = entity.RatingsList,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        public bool UpdateWorkout(WorkoutsEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Workouts
                    .Single(e => e.Id == model.Id && e.UserId == _userId);

                entity.Name = model.Name;
                entity.RatingsList = model.RatingsList;
                entity.CreatedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
