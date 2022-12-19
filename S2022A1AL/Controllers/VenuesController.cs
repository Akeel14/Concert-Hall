using S2022A1AL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A1AL.Controllers
{
    public class VenuesController : Controller
    {
        private Manager m = new Manager();
        public ActionResult Index()
        {
            var c = m.VenueGetAll();
            return View(c);
        }

        public ActionResult Details(int? id)
        {
       
            var obj = m.VenueGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VenueAddViewModel newItem)
        {

            if (!ModelState.IsValid)
                return View(newItem);
            try
            {
                var addedItem = m.VenueAdd(newItem);
                if (addedItem == null)
                    return View(newItem);
                else
                    return RedirectToAction("Details", new { id = addedItem.VenueId });
            }
            catch
            {
                return View(newItem);
            }
        }

       
        public ActionResult Edit(int? id)
        {
           
            var obj = m.VenueGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            else
            {
                var formObj = m.mapper.Map<VenueBaseViewModel, VenueEditFormViewModel>(obj);
                return View(formObj);
            }
        }


        [HttpPost]
        public ActionResult Edit(int? id, VenueEditViewModel model)
        {
          
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = model.VenueId });
            }
            if (id.GetValueOrDefault() != model.VenueId)
            {
                return RedirectToAction("Index");
            }

            var editedItem = m.VenueEditVenueInfo(model);
            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = model.VenueId });
            }
            else
            {
                return RedirectToAction("Details", new { id = model.VenueId });
            }
        }

        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.VenueGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
                return View(itemToDelete);
        }

        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.VenueDelete(id.GetValueOrDefault());
           
            return RedirectToAction("Index");
        }
    }
}
