using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutApp.Data;
using WorkoutApp.Models;

namespace WorkoutApp.Services
{
    public class RatingsService
    {
        private readonly Guid _userId;
        public RatingsService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(RatingsCreate model)
        {
            var entity =
                new Ratings()
                {
                    WorkoutPlanId = model.WorkoutPlanId,
                    ExertionScore = model.ExertionScore,
                    EnjoymentScore = model.EnjoymentScore,
                    HeartrateScore = model.HeartrateScore
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingsListItem> GetRating()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ratings
                        //.Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new RatingsListItem
                                {
                                    Id = e.Id,
                                    AverageScore = e.AverageScore
                                }
                        );

                return query.ToArray();
            }
        }

        public RatingsDetail GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.Id == id);
                return
                    new RatingsDetail
                    {
                        Id = entity.Id,
                        WorkoutPlanId = entity.WorkoutPlanId,
                        ExertionScore = entity.ExertionScore,
                        EnjoymentScore = entity.EnjoymentScore,
                        HeartrateScore = entity.HeartrateScore
                    };
            }
        }

        public bool UpdateRating(RatingsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.Id == model.Id && e.UserId == _userId);

                entity.Id = model.Id;
                entity.ExertionScore = model.ExertionScore;
                entity.EnjoymentScore = model.EnjoymentScore;
                entity.HeartrateScore = model.HeartrateScore;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.Id == Id && e.UserId == _userId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
