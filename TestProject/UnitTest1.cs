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
        private ApplicationDbContext _context; // Make sure _context is initialized or injected
        // [SetUp]
        // public void Setup()
        // {
        // }
        [SetUp]
        public void Setup()
        {
            // Initialize an in-memory database context
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;
            _context = new ApplicationDbContext(options);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
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

       // Test to check whether CanteenOrder Models Class exists
        [Test]
        public void CanteenOrder_Models_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.CanteenOrder";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CanteenOrderType = assembly.GetType(typeName);
            Assert.IsNotNull(CanteenOrderType);
        }

        // Test to Check CanteenOrder Models Property OrderId Exists with correcct datatype int    
        [Test]
        public void CanteenOrder_OrderId_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.CanteenOrder";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CanteenOrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CanteenOrderType.GetProperty("OrderId");
            Assert.IsNotNull(propertyInfo, "Property OrderId does not exist in CanteenOrder class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property OrderId in CanteenOrder class is not of type int");
        }

        // Test to Check CanteenOrder Models Property CustomerName Exists with correcct datatype string    
        [Test]
        public void CanteenOrder_CustomerName_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.CanteenOrder";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CanteenOrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CanteenOrderType.GetProperty("CustomerName");
            Assert.IsNotNull(propertyInfo, "Property CustomerName does not exist in CanteenOrder class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property CustomerName in CanteenOrder class is not of type string");
        }

        // Test to Check CanteenOrder Models Property FoodItem Exists with correcct datatype string    
        [Test]
        public void CanteenOrder_FoodItem_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.CanteenOrder";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CanteenOrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CanteenOrderType.GetProperty("FoodItem");
            Assert.IsNotNull(propertyInfo, "Property FoodItem does not exist in CanteenOrder class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property FoodItem in CanteenOrder class is not of type string");
        }

        // Test to Check CanteenOrder Models Property SpecialInstructions Exists with correcct datatype string    
        [Test]
        public void CanteenOrder_SpecialInstructions_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.CanteenOrder";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CanteenOrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CanteenOrderType.GetProperty("SpecialInstructions");
            Assert.IsNotNull(propertyInfo, "Property SpecialInstructions does not exist in CanteenOrder class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property SpecialInstructions in CanteenOrder class is not of type string");
        }

        // Test to Check CanteenOrder Models Property Quantity Exists with correcct datatype int    
        [Test]
        public void CanteenOrder_Quantity_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.CanteenOrder";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CanteenOrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CanteenOrderType.GetProperty("Quantity");
            Assert.IsNotNull(propertyInfo, "Property Quantity does not exist in CanteenOrder class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property Quantity in CanteenOrder class is not of type int");
        }

        // Test to Check CanteenOrder Models Property OrderDate Exists with correcct datatype DateTime    
        [Test]
        public void CanteenOrder_OrderDate_PropertyExists_ReturnExpectedDataTypes_DateTime()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.CanteenOrder";
            Assembly assembly = Assembly.Load(assemblyName);
            Type canteenOrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = canteenOrderType.GetProperty("OrderDate");
            Assert.IsNotNull(propertyInfo, "Property OrderDate does not exist in CanteenOrder class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(DateTime), expectedType, "Property OrderDate in CanteenOrder class is not of type DateTime");
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

        // Test to Check OrderController Controllers Method Create with parameter Exists
        [Test]
        public void OrderController_Create_Method_with_ElectionCandidate_Param_Exists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.OrderController";
            Assembly assembly = Assembly.Load(assemblyName);
            string typeName1 = "dotnetapp.Models.CanteenOrder";
            Type canteenOrderType = assembly.GetType(typeName1);
            object instance1 = Activator.CreateInstance(canteenOrderType);
            Type OrderControllerType = assembly.GetType(typeName);
            object instance = Activator.CreateInstance(OrderControllerType, _context);
            MethodInfo methodInfo = OrderControllerType.GetMethod("Create", new Type[] { canteenOrderType });
            Assert.IsNotNull(methodInfo, "Result should not be null");
        }
        
       // Test to check that Create method in OrderController adds a new order to the database
        [Test]
        public void Create_in_OrderController_Add_new_Order_to_DB()
        {
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string canteenOrderTypeName = "dotnetapp.Models.CanteenOrder";
            Type canteenOrderType = assembly.GetType(canteenOrderTypeName);

            // Create a new instance of CanteenOrder with required properties
            var canteenOrderInstance = new CanteenOrder
            {
                CustomerName = "John Doe",
                FoodItem = "Burger",
                Quantity = 4,
                SpecialInstructions = "No onions"
            };
            string orderControllerTypeName = "dotnetapp.Controllers.OrderController";
            Type orderControllerType = assembly.GetType(orderControllerTypeName);
            object orderControllerInstance = Activator.CreateInstance(orderControllerType, _context);

            // Get the Create method of OrderController
            var method = orderControllerType.GetMethod("Create", new Type[] { canteenOrderType });

            // Invoke the Create method with the created CanteenOrder instance
            var result = method.Invoke(orderControllerInstance, new[] { canteenOrderInstance }) as IActionResult;
            Assert.IsNotNull(result);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectResult.ActionName);

            // Retrieve all orders from the context and assert that there is one order present
            var orders = _context.CanteenOrders.ToList();
            Assert.AreEqual(1, orders.Count);
        }
    }
}