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
        [SetUp]
        public void Setup()
        {
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


    }
}