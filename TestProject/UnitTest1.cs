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

        // Test to check that ApplicationDbContext Contains DbSet for model ElectionCandidate
        [Test]
        public void ApplicationDbContext_ContainsDbSet_ElectionCandidate()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(ApplicationDbContext));
            Type contextType = assembly.GetTypes().FirstOrDefault(t => typeof(DbContext).IsAssignableFrom(t));
            if (contextType == null)
            {
                Assert.Fail("No DbContext found in the assembly");
                return;
            }
            Type ElectionCandidateType = assembly.GetTypes().FirstOrDefault(t => t.Name == "ElectionCandidate");
            if (ElectionCandidateType == null)
            {
                Assert.Fail("No DbSet found in the DbContext");
                return;
            }
            var propertyInfo = contextType.GetProperty("ElectionCandidates");
            if (propertyInfo == null)
            {
                Assert.Fail("ElectionCandidates property not found in the DbContext");
                return;
            }
            else
            {
                Assert.AreEqual(typeof(DbSet<>).MakeGenericType(ElectionCandidateType), propertyInfo.PropertyType);
            }
        }

        // Test to check whether CandidateController Controllers Class exists
        [Test]
        public void CandidateController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(CandidateControllerType);
        }

        // Test to Check CandidateController Controllers Method Index Exists
        [Test]
        public void CandidateController_Index_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CandidateControllerType.GetMethod("Index");
            Assert.IsNotNull(methodInfo, "Method Index does not exist in CandidateController class");
        }


        // Test to Check CandidateController Controllers Method Index with no parameter Returns IActionResult
        [Test]
        public void CandidateController_Index_Method_with_NoParams_Returns_IActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CandidateControllerType.GetMethod("Index", Type.EmptyTypes);
            Assert.AreEqual(typeof(IActionResult), methodInfo.ReturnType, "Method Index in CandidateController class is not of type IActionResult");
        }

        // Test to Check CandidateController Controllers Method Create Exists
        [Test]
        public void CandidateController_Create_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CandidateControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method Create does not exist in CandidateController class");
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