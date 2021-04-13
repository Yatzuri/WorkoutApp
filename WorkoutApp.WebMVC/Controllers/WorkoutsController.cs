using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutApp.Data;
using WorkoutApp.Models;
using WorkoutApp.Services;

namespace WorkoutApp.WebMVC.Controllers
{
    [Authorize]
    public class WorkoutsController : Controller
    {
        // GET: Workouts
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutsService(userId);
            var model = service.GetWorkouts();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(WorkoutsCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWorkoutsService();

            if (service.CreateWorkout(model))
            {
                TempData["SaveResult"] = "Your Workout was Created. Are you ready to design it?";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Workout could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateWorkoutsService();
            var model = svc.GetWorkoutById(id);

            return View(model);
        }

        private WorkoutsService CreateWorkoutsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutsService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateWorkoutsService();
            var detail = service.GetWorkoutById(id);
            var model =
                new WorkoutsEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Rating = detail.Ratings
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkoutsEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWorkoutsService();

            if (service.UpdateWorkout(model))
            {
                TempData["SaveResult"] = "Your workout was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your workout could not be updated.");

            return View(model);
        }

        public bool DeleteWorkout(int Id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Workouts
                        .Single(e => e.Id == Id && e.UserId == userId);

                ctx.Workouts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWorkoutsService();
            var model = svc.GetWorkoutById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWorkoutsService();

            service.DeleteWorkout(id);

            TempData["SaveResult"] = "Your workout was deleted";

            return RedirectToAction("Index");
        }
    }
}