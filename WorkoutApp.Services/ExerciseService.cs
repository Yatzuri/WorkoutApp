using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutApp.Data;
using WorkoutApp.Models;

namespace WorkoutApp.Services
{
    public class ExerciseService
    {
        private readonly Guid _userId;
        public ExerciseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateExercise(ExerciseCreate model)
        {
            var entity =
                new Exercise()
                {
                    WorkoutPlanId = model.WorkoutPlanId,
                    Name = model.Name,
                    Level = model.Level
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Exercises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ExerciseListItem> GetExercises()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exercises
                        //.Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ExerciseListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    Level = e.Level
                                }
                        );

                return query.ToArray();
            }
        }

        public ExerciseDetail GetExerciseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Exercises
                    .Single(e => e.Id == id);
                return
                    new ExerciseDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Sets = entity.Sets,
                        Reps = entity.Reps,
                        Level = entity.Level
                    };
            }
        }

        public bool UpdateExercise(ExerciseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Exercises
                    .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Sets = model.Sets;
                entity.Reps = model.Reps;
                entity.Level = model.Level;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteExercise(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.Id == Id && e.OwnerId == _userId);

                ctx.Exercises.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
