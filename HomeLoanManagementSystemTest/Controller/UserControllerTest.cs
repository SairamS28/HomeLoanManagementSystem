//using System;
//using System.Collections.Generic;
//using System.Text;
//using NUnit.Framework;
//using HomeLoanManagementSystem;
//using HomeLoanManagementSystem.Controllers;
//using HomeLoanManagementSystem.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Threading.Tasks;

//namespace HomeLoanManagementSystemTest.Controller
//{
//    public class Tests
//    {
//        [SetUp]
//        public void Setup()
//        {
//            //UserController _userController = new UserController();
//        }

//        //[Test]
//        //public void DetailsTest()
//        //{
//        //    //Arrange
//        //    User _user=new User() {Mobile=9790125226,Password="Sairam2810",Email= "ssairamsuratkumar@deloitte.com",Address= "C1-101,First Floor  Terraspace Sumeru",Name= "S Sairamsuratkumar",DateOfBirth= "2022-08-10 14:10:00.0000000" };
//        //    UserController _userController = new UserController();
//        //    //Act
//        //    ViewResult result = _userController.Login() as ViewResult;
//        //    var model = (Login)result.Model;
//        //    //Assert
//        //    Assert.AreEqual(_login.Mobile, model.Mobile);
//        //    Assert.AreEqual(_login.Password, model.Password);
//        //}
//        [Test]
//        public void ApplicationViewBagTest()
//        {
//            //Arrange
//           // UserController controller = new UserController();
//            //Act
//            ViewResult result = controller.Application() as ViewResult;
//            //Assert
//            Assert.IsNotNull(result);
//        }
//        [Test]
//        public void LoginTest()
//        {
//            //Arrange
//           // UserController controller = new UserController();
//            //Act
//            ViewResult result = controller.Login() as ViewResult;
//            //Assert
//            Assert.IsNotNull(result);

//        }
//        [Test]
//        public void DetailsTest()
//        {
//            //Arrange
//            UserController controller = new UserController();
//            //Act
//            Task task = controller.Details() as Task;

//            //Assert
//            Assert.IsNotNull(task);
//        }
//    }
//}