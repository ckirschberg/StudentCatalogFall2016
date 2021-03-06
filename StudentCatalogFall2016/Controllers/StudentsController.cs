﻿using StudentCatalogFall2016.Models;
using StudentCatalogFall2016.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCatalogFall2016.Controllers
{
    public class StudentsController : Controller
    {

        private IStudentsRepository studentRepo;
        public StudentsController(IStudentsRepository repo)
        {
            this.studentRepo = repo;
        }




        // Find(int id)
        public StudentModel Find(int? id)
        {
            StudentModel student = studentRepo.Find(id);
            return student;
        }

        [AllowAnonymous]
        public ActionResult Index(string search="")
        {
            //JsonResult
            //return data as Json (api)
            //return Json(studentRepo.GetAll(), JsonRequestBehavior.AllowGet);

            var results = studentRepo.GetAll();
            if (!String.IsNullOrEmpty(search))
            {
                var searchedNames = from s in results
                                    where s.Firstname.ToLower()
                                        .Contains(search.ToLower()) || 
                                        s.Lastname.ToLower().Contains(search.ToLower())

                                    select s;

                results = searchedNames;
            }

            return View(results.ToList());






            //List<StudentModel> students = studentRepo.GetAll();

            //var filter = students
            //    .Where(a => a.Firstname.Contains("t"))
            //    .Select(a => a.Firstname);





            //var studentsFirstnames =
            //    from s in students
            //    where s.Lastname.Contains("e")
            //    select s;

            //var students = studentRepo.GetAll()
            //    .Where(a => a.Firstname == "Troels").ToList();

            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords =
                (from w in words
                select new { Upper = w.ToUpper(), Lower = w.ToLower() }).ToList();


           
            //Console.WriteLine("Product Names:");
            //foreach (var productName in productNames)
            //{
            //    Console.WriteLine(productName);
            //}





            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsPlusOne =
                from n in numbers
                select n + 1;

            Console.WriteLine("Numbers + 1:");
            foreach (var i in numsPlusOne)
            {
                Console.WriteLine(i);
            }

            return View(studentRepo.GetAll());
        }

        public ActionResult WannaPlay()
        {
            ViewBag.Message = "Yes, I wanna play";
            ViewBag.Troels = "Rules the world!";
            return View();
        }

        // Create view 
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        // HTTP Post: create new student to ORM DB
        [HttpPost]
        public ActionResult Create(StudentModel student)
        {
          
                if (ModelState.IsValid)
                {
                    //then I want to save the student object
                    studentRepo.InsertOrUpdate(student);

                    return RedirectToAction("Index");
                }
                return View();
            
        }

        // - Get student from the db
        // - view - fields
        // edit action method
        // validtion
        [HttpGet]
        // int? just tells the int it can be null
        public ActionResult Edit(int? id)
        {
            // if no id is found
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            StudentModel student = studentRepo.Find(id);
            // if the student is not found in the ORM

            if (student == null)
            {
                return new HttpNotFoundResult();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                // How to update sql statement
                studentRepo.InsertOrUpdate(student);
                return RedirectToAction("Index");
            }
            return View("Thanks for Editing the ");
        }

        // Make the Delete function
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            studentRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}