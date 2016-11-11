using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentCatalogFall2016;
using StudentCatalogFall2016.Controllers;
using StudentCatalogFall2016.Models;
using Moq;
using StudentCatalogFall2016.Models.Entity;

namespace StudentCatalogFall2016.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestCreateStudent()
        {
            //Arrange
            //Create a StudentsController obj.
            //Want to pass a mock
            var mockRepo = new Mock<IStudentsRepository>();
            StudentsController controller = new StudentsController(mockRepo.Object);
            StudentModel student = new StudentModel() { Firstname = "Edgaras", Lastname = "Something", Email = "edgaras@edgaras.dk", MobilePhone = "12312312" };

            //Act
            controller.Create(student);

            //Assert
            mockRepo.Verify(repo => repo.InsertOrUpdate(student));
            
        }


        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
