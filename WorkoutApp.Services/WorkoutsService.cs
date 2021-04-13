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
                    Rating = model.Ratings,
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
                            { var ratings = e.Ratings 



                                new WorkoutsListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                };
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
                        Ratings = entity.Rating,
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
                entity.Ratings = model.Ratings;
                entity.CreatedUtc = DateTimeOffset.UtcNow;
                entity.IsStarred = model.IsStarred;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWorkout(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Workouts
                        .Single(e => e.Id == Id && e.UserId == _userId);

                ctx.Workouts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
