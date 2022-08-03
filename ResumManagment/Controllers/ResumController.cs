using Microsoft.AspNetCore.Mvc;
using ResumManagment.Models;
using ResumManagment.Repository;
using ResumManagment.ViewModel;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace ResumManagment.Controllers
{
    [Authorize]
    public class ResumController : Controller
    {
        private readonly IApplicatRepo repo;

        public ResumController(IApplicatRepo repo) 
        {
            this.repo = repo;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            ResumIndexViewModel resumIndex = new ResumIndexViewModel
            {
                Applicats = repo.GetAll(),
                Title = "resum index"
            };
            return View(resumIndex);   
        }
        [HttpGet]
        public ViewResult Create() 
        {
            Applicat applicat = new Applicat();
            applicat.Experions.Add(new Experions() { Id = 1 });

            ViewBag.gender = repo.GetGender();

            return View(applicat);
        }
        [HttpPost]
        public IActionResult Create(Applicat applicat)
        {
            if (ModelState.IsValid)
            {
                repo.Create(applicat);
                return RedirectToAction("Index");
            }
            return View(); 
        }

        public IActionResult Details(int id) 
        {
            var model = repo.GetById(id);

            return View(model);
        
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var applicat = repo.GetById(id);
            if (applicat != null)
            {
                repo.Delete(applicat);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
