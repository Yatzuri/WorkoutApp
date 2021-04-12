using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            var service = CreateWorkoutService();

            if (service.CreateWorkouts(model))
            {
                TempData["SaveResult"] = "Your Workout was Created. Are you ready to design it?";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateWorkoutService();
            var model = svc.GetNoteById(id);

            return View(model);
        }

        private WorkoutsService NewMethod()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkoutsService(userId);
            return service;
        }
    }
}