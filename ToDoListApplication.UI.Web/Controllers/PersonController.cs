using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ToDoListApplication.ApplicationServices.Interface;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.UI.Web.ViewModels;
using ToDoListApplication.UI.Web.Extension_Methods;
using System.Web;

namespace ToDoListApplication.UI.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IAppPersonService _personService;

        public PersonController(IAppPersonService personService)
        {
            _personService = personService;
        }

        public ActionResult Index()
        {
            var people = _personService.GetAll();
            var peopleViewModel = this.ConvertEntity<IEnumerable<Person>, IEnumerable<PersonViewModel>>(people);
            return View(peopleViewModel);
        }

        public ActionResult Details(int id)
        {
            PersonViewModel personViewModel = this.ConvertEntity<Person, PersonViewModel>(_personService.GetById(id));
            return View(personViewModel);
        }

        public ActionResult Create()
        {
            return View("Form");
        }

        public ActionResult Edit(int id)
        {
            PersonViewModel personViewModel = this.ConvertEntity<Person, PersonViewModel>(_personService.GetById(id));
            return View("Form", personViewModel);
        }

        public ActionResult Delete(int id)
        {
            PersonViewModel personViewModel = this.ConvertEntity<Person, PersonViewModel>(_personService.GetById(id));
            return View(personViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = _personService.GetById(id);
            _personService.Delete(person);
            return RedirectToAction(nameof(PersonController.Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveOrUpdate(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                var imageUploaded = personViewModel.AvatarImage;

                if (imageUploaded != null)                
                    _personService.UploadImage(imageUploaded);
                                
                Person person = this.ConvertEntity<PersonViewModel, Person>(personViewModel);

                if (person.Id > 0)
                {
                    _personService.Update(person);
                }
                else
                {
                    _personService.Add(person);
                }
                return RedirectToAction(nameof(PersonController.Index));
            }
            return View("Form", personViewModel);
        }

    }
}
