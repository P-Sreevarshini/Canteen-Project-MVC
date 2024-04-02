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
        // test to check that Create method in CandidateController adds new candidate to db
        [Test]
        public void Create_in_CandidateController_Add_new_Candidate_to_DB()
        {
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string modelType = "dotnetapp.Models.ElectionCandidate";
            string controllerTypeName = "dotnetapp.Controllers.CandidateController";
            Type controllerType = assembly.GetType(controllerTypeName);
            Type controllerType2 = assembly.GetType(modelType);
            
                var teamData = new Dictionary<string, object>
                    {
                        { "StudentName", "Demo1" },
                        { "Standard", "X" },
                        { "PositionAppliedFor", "Vice-President" },
                        { "ContactEmail", "Demo1@gmail.com" },
                        { "CampaignPlatform", "Xyz ABC" }
                    };
            var commuter = new ElectionCandidate();
                foreach (var kvp in teamData)
                {
                    var propertyInfo = typeof(ElectionCandidate).GetProperty(kvp.Key);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(commuter, kvp.Value);
                    }
                }
                MethodInfo method = controllerType.GetMethod("Create", new[] { controllerType2 });

                if (method != null)
                {

                    var controller = Activator.CreateInstance(controllerType, _context);
                    var result = method.Invoke(controller, new object[] { commuter });
                    var ride = _context.ElectionCandidates.ToList().FirstOrDefault(o => (int)o.GetType().GetProperty("StudentId").GetValue(o) == 1);
                    Assert.IsNotNull(result);
                    Assert.AreEqual("X", (string)ride.GetType().GetProperty("Standard").GetValue(ride));
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
}