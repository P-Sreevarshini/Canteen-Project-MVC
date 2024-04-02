using System.Numerics;
using dotnetapp.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TestProject
{
    public class Tests
    {
        private ApplicationDbContext _context;
        [SetUp]
        public void Setup()
        {
            var _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
            _context = new ApplicationDbContext(_dbContextOptions);
        }
        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        // Test to check that ApplicationDbContext Contains DbSet for model CanteenOrder
        [Test]
        public void ApplicationDbContext_ContainsDbSet_CanteenOrder()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(ApplicationDbContext));
            Type contextType = assembly.GetTypes().FirstOrDefault(t => typeof(DbContext).IsAssignableFrom(t));
            if (contextType == null)
            {
                Assert.Fail("No DbContext found in the assembly");
                return;
            }
            Type CanteenOrderType = assembly.GetTypes().FirstOrDefault(t => t.Name == "CanteenOrder");
            if (CanteenOrderType == null)
            {
                Assert.Fail("No DbSet found in the DbContext");
                return;
            }
            var propertyInfo = contextType.GetProperty("CanteenOrders");
            if (propertyInfo == null)
            {
                Assert.Fail("CanteenOrders property not found in the DbContext");
                return;
            }
            else
            {
                Assert.AreEqual(typeof(DbSet<>).MakeGenericType(CanteenOrderType), propertyInfo.PropertyType);
            }
        }

        // Test to check whether OrderController Controllers Class exists
        [Test]
        public void OrderController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.OrderController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(OrderControllerType);
        }

        // Test to Check OrderController Controllers Method Index Exists
        [Test]
        public void OrderController_Index_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.OrderController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = OrderControllerType.GetMethod("Index");
            Assert.IsNotNull(methodInfo, "Method Index does not exist in OrderController class");
        }


        
        // Test to Check OrderController Controllers Method Create Exists
        [Test]
        public void OrderController_Create_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.OrderController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = OrderControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method Create does not exist in OrderController class");
        }


        // Test to Check CandidateController Controllers Method Create with no parameter Returns IActionResult
        [Test]
        public void CandidateController_Create_Method_with_NoParams_Returns_IActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CandidateControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.AreEqual(typeof(IActionResult), methodInfo.ReturnType, "Method Create in CandidateController class is not of type IActionResult");
        }
    }
}