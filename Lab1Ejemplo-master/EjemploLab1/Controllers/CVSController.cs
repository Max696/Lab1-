using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploLab1.DBContext;
using System.IO;
using EjemploLab1.DBContext;
using EjemploLab1.Models;

namespace EjemploLab1.Controllers
{
    public class CVSController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;

        // GET: CVS
        public ActionResult Index()
        {

            return RedirectToAction("CreatePerson");
        }

        // GET: CVS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CVS/Create
        [HttpGet]
        public ActionResult CreatePerson()
        {
            return View();
        }

        // POST: CVS/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase excelFile)
        {
            try
            {
                string Fpath = string.Empty;
                if(excelFile!=null)
                {
                    string path= Server.MapPath("~/Files/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    Fpath = path + Path.GetFileName(excelFile.FileName);
                    string extension = Path.GetExtension(excelFile.FileName);
                    excelFile.SaveAs(Fpath);
                    string csvData = System.IO.File.ReadAllText(Fpath);
                    int count = 0;
                    foreach (var row in csvData.Split('\n'))

                    {
                        if( !string.IsNullOrEmpty(row))
                        {
                            if (count ==0)
                            {
                                count++;
                            }
                            else
                            {
                                db.Personas.Add(new Persona
                                {
                                    Club = row.Split(',')[0],
                                    Apellido = row.Split(',')[1],
                                    Nombre = row.Split(',')[2],
                                    Posicion = row.Split(',')[3],
                                    Salario = double.Parse(row.Split(',')[4]),
                                    
                                });
                            }


                        }
                        
                    }
                }
                return View(db.Personas);
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
