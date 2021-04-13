using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkoutApp.Models;
using WorkoutApp.Services;

namespace WorkoutApp.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Workout")]
    public class WorkoutsController : ApiController
    {
        private bool SetStarState(int Id, bool newState)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutsService(userId);

            var detail = service.GetWorkoutById(Id);

            var updateWorkout =
                     new WorkoutsEdit
                     {
                         Id = detail.Id,
                         Name = detail.Name,
                         RatingsList = detail.RatingsList,
                         IsStarred = newState
                     };
            return service.UpdateWorkout(updateWorkout);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);

    }

}
