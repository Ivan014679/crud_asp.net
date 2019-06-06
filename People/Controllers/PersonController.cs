using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace People.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            PersonModel pModel = new PersonModel();
            pModel.List = pModel.Consult();
            return View(pModel);
        }

        public ActionResult CreatePerson()
        {
             return View();

        }

        [HttpPost]
        public ActionResult CreatePerson(PersonModel pModel)
        {
            if (ModelState.IsValid)
            {
                pModel.Create();
                return RedirectToAction("Index");
            }
            else
            {
                return View(pModel);
            }
        }

        [HttpPost]
        public ActionResult UpdatePerson(decimal id)
        {
            PersonModel pModel = new PersonModel();
            pModel = pModel.ConsultOne(id);
            return View(pModel);
        }

        [HttpPost]
        public ActionResult SaveChanges(PersonModel pModel)
        {
            if (ModelState.IsValid)
            {
                pModel.Update();
                return RedirectToAction("Index");
            }
            else
            {
                return View(pModel);
            }            
        }

        [HttpPost]
        public ActionResult DeletePerson(decimal id)
        {
            PersonModel pModel = new PersonModel();
            pModel.Delete(id);
            return RedirectToAction("Index");
        }
    }
}