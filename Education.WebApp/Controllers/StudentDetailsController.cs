﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Core.Students;
namespace Education.WebApp.Controllers
{
    public class StudentDetailsController : Controller
    {
       

        // GET: StudentDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentDetails/Create
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

        // GET: StudentDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentDetails/Edit/5
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

        // GET: StudentDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentDetails/Delete/5
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
