using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploLab1.DBContext;

namespace EjemploLab1.Controllers
{
    public class CVSController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;

        // GET: CVS
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }

        // GET: CVS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CVS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CVS/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CVS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CVS/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CVS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CVS/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
