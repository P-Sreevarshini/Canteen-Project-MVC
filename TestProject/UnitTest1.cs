using NUnit.Framework;
using System;
using System.Linq;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace dotnetapp.Tests
{
    [TestFixture]
    public class OrderControllerTests
    {
        [Test]
        public void OrderController_Exists()
        {
            // Arrange
            var controller = new OrderController(null);

            // Act & Assert
            Assert.NotNull(controller);
        }

        [Test]
        public void OrderController_Constructor_Injects_ApplicationDbContext_Correctly()
        {
            // Arrange
            var dbContext = new ApplicationDbContext(null);
            var controller = new OrderController(dbContext);

            // Act & Assert
            Assert.NotNull(controller);
            Assert.NotNull(controller.GetType().GetProperty("_context"));
        }

        [Test]
        public void Index_Returns_ViewResult()
        {
            // Arrange
            var dbContext = new ApplicationDbContext(null);
            var controller = new OrderController(dbContext);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Index_Returns_ViewResult_With_OrderList()
        {
            // Arrange
            var dbContext = new ApplicationDbContext(null);
            var controller = new OrderController(dbContext);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.IsAssignableFrom<IQueryable<CanteenOrder>>(result.Model);
        }

        [Test]
        public void Create_Returns_ViewResult()
        {
            // Arrange
            var dbContext = new ApplicationDbContext(null);
            var controller = new OrderController(dbContext);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Create_Post_Redirects_To_Index()
        {
            // Arrange
            var dbContext = new ApplicationDbContext(null);
            var controller = new OrderController(dbContext);
            var order = new CanteenOrder { CustomerName = "John Doe", FoodItem = "Pizza", Quantity = 2 };

            // Act
            var result = controller.Create(order) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }

        [Test]
        public void Create_Post_Returns_ViewResult_With_Invalid_Model_State()
        {
            // Arrange
            var dbContext = new ApplicationDbContext(null);
            var controller = new OrderController(dbContext);
            controller.ModelState.AddModelError("CustomerName", "Customer Name is required");
            var order = new CanteenOrder();

            // Act
            var result = controller.Create(order);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        // Additional test cases can be added for other methods and scenarios
    }

    [TestFixture]
    public class CanteenOrderTests
    {
        [Test]
        public void CanteenOrder_Exists()
        {
            // Arrange & Act & Assert
            Assert.NotNull(typeof(CanteenOrder));
        }

        [Test]
        public void CanteenOrder_Has_OrderId_Property()
        {
            // Arrange & Act & Assert
            Assert.NotNull(typeof(CanteenOrder).GetProperty("OrderId"));
        }

        [Test]
        public void OrderId_Property_Has_Key_Attribute()
        {
            // Arrange
            var property = typeof(CanteenOrder).GetProperty("OrderId");

            // Act
            var keyAttribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute));

            // Assert
            Assert.NotNull(keyAttribute);
        }
         [Test]
        public void Create_View_Exists()
        {
            // Arrange
            var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "Order", "Create.cshtml");

            // Act & Assert
            Assert.True(File.Exists(viewPath));
        }

        [Test]
        public void Index_View_Exists()
        {
            // Arrange
            var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "Order", "Index.cshtml");

            // Act & Assert
            Assert.True(File.Exists(viewPath));
        }


    }
}
