using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitnessBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUsersDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var gender = "mal";
            var birthdate = DateTime.Now.AddYears(18);
            var weight = 8;
            var height = 180;
            var controller = new UserController(userName);
            controller.SetNewUsersData(gender, birthdate, weight, height);

            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName =Guid.NewGuid().ToString(); 
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}