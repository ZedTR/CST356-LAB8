using Lab8.Data.Entities;
using Lab8.Models.ViewModel;
using Lab8.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab8.Controllers
{
    public class WatchesController : Controller
    {

        private readonly IWatchesServices s;

        public WatchesController(IWatchesServices service)
        {
            s = service;
        }
        // GET: Watches
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();
            var watches = s.GetUsersWatches(userId);
            return View(watches);

        }


        // GET: Watches/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Watches/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            return View();
        }

        // POST: Watches/Create
        [HttpPost]
        public ActionResult Create(WatchesViewModel watches)
        {
            if (!ModelState.IsValid)
            {
                return View(watches);
            }
            watches.UserId = User.Identity.GetUserId();
            s.CreateWatch(watches);
            return RedirectToAction("List");
        }

        // GET: Watches/Edit/5
        public ActionResult Edit(int id)
        {
            return View(s.GetWatches(id));
        }

        // POST: Watches/Edit/5
        [HttpPost]
        public ActionResult Edit(WatchesViewModel watches)
        {
            s.UpdateWatch(watches);
            return RedirectToAction("List");
        }

        // GET: Watches/Delete/5
        public ActionResult Delete(int id)
        {
            return View(s.GetWatches(id));
        }

        // POST: Watches/Delete/5
        [HttpPost]
        public ActionResult Delete(WatchesViewModel watches)
        {
            var userId = User.Identity.GetUserId();

            s.DeleteWatch(watches.Id);
            return RedirectToAction("List");

        }
    }
}
