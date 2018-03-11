using Lab8.Models.View;
using Lab8.Service;
using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Lab8.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly IPetService s;

        public PetController(IPetService service)
        {
            s = service;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();
             var pets = s.GetUsersPets(userId);
             return View(pets);
       
        }

        [HttpGet]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetViewModel pet)
        {
            if (!ModelState.IsValid)
            {
                return View(pet);
            }
            pet.UserId = User.Identity.GetUserId();
            s.CreatePet(pet);
            return RedirectToAction("List");
 
        }

        public ActionResult Details(int id)
        {
           return View(s.GetPet(id)); 
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
         return View(s.GetPet(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PetViewModel pet)
        {
            s.UpdatePet(pet);
            return RedirectToAction("List");
           
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
          return View(s.GetPet(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PetViewModel pet)
        {
            var userId = User.Identity.GetUserId();
 
            s.DeletePet(pet.Id);
            return RedirectToAction("List");
              
        }
    }
}