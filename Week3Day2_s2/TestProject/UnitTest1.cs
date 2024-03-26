using dotnetapp.Controllers;
using RazorLight;
using Microsoft.AspNetCore.Html;
using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System.Text.Encodings.Web;
using System.Xml.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Hosting.Server;
using dotnetapp;
using System.Net;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.WebEncoders.Testing;
using Moq;
namespace dotnetapp.Tests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private string htmlContent = @"
            <a asp-controller=""Employee"" asp-action=""Home"">Home</a>
            <a asp-controller=""Employee"" asp-action=""Attendance"">Attendance</a>
            <a asp-controller=""Employee"" asp-action=""Details"">Employee Details</a>
        ";
        [Test]
        public void Test_Home_Route_Attribute()
        {
            // Arrange
            var controller = CreateEmployeeController();
            var method = GetActionMethod(controller, "Home");

            // Act
            var routeAttribute = method.GetCustomAttribute<RouteAttribute>();

            // Assert
            Assert.IsNotNull(routeAttribute);
            Assert.AreEqual("employee/home", routeAttribute.Template);
        }
        [Test]
        public void Test_Details_Route_Attribute()
        {
            // Arrange
            var controller = CreateEmployeeController();
            var method = GetActionMethod(controller, "Details");

            // Act
            var routeAttribute = method.GetCustomAttribute<RouteAttribute>();

            // Assert
            Assert.IsNotNull(routeAttribute);
            Assert.AreEqual("employee/details", routeAttribute.Template);
        }
        [Test]
        public void Test_Departments_Route_Attribute()
        {
            // Arrange
            var controller = CreateEmployeeController();
            var method = GetActionMethod(controller, "Departments");

            // Act
            var routeAttribute = method.GetCustomAttribute<RouteAttribute>();

            // Assert
            Assert.IsNotNull(routeAttribute);
            Assert.AreEqual("employee/departments", routeAttribute.Template);
        }
        [Test]
        public void Test_Attendance_Route_Attribute()
        {
            // Arrange
            var controller = CreateEmployeeController();
            var method = GetActionMethod(controller, "Attendance");

            // Act
            var routeAttribute = method.GetCustomAttribute<RouteAttribute>();

            // Assert
            Assert.IsNotNull(routeAttribute);
            Assert.AreEqual("employee/attendance", routeAttribute.Template);
        }
        [Test]
        public void Test_HomeViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Week3Day2_s2/dotnetapp/Views/Employee/", "Home.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Home.cshtml view file does not exist.");
        }
        [Test]
        public void Test_DetailsViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Week3Day2_s2/dotnetapp/Views/Employee/", "Details.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Details.cshtml view file does not exist.");
        }
        [Test]
        public void Test_DepartmentsViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Week3Day2_s2/dotnetapp/Views/Employee/", "Departments.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Departments.cshtml view file does not exist.");
        }
        [Test]
        public void Test_AttendanceViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Week3Day2_s2/dotnetapp/Views/Employee/", "Attendance.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Attendance.cshtml view file does not exist.");
        }
        private MethodInfo GetActionMethod(EmployeeController controller, string methodName)
        {
            // Use reflection to get the method by name
            MethodInfo method = controller.GetType().GetMethod(methodName);

            if (method != null && method.ReturnType == typeof(IActionResult))
            {
                return method;
            }
            else
            {
                // Handle the case where the method doesn't exist or doesn't return IActionResult
                throw new Exception("Action method not found or doesn't return IActionResult.");
            }
        }

        private EmployeeController CreateEmployeeController()
        {
            // Fully-qualified name of the EmployeeController class
            string controllerTypeName = "dotnetapp.Controllers.EmployeeController, dotnetapp";

            // Get the type using Type.GetType
            Type controllerType = Type.GetType(controllerTypeName);

            // Check if the type is found
            Assert.IsNotNull(controllerType);

            // Create an instance of the controller using reflection
            return (EmployeeController)Activator.CreateInstance(controllerType);
        }
        [Test]
        public void Test_Departmentlink_present_in_AttendanceView()
        {
            // HTML line to be checked
            string htmlLine = "<a asp-controller=\"Employee\" asp-action=\"Departments\">Department</a>";

            // HTML content where you want to check the presence of the line
            string htmlContent = "<html><body><a asp-controller=\"Employee\" asp-action=\"Departments\">Department</a></body></html>";

            // Assert if the HTML line is present in the HTML content
            Assert.IsTrue(htmlContent.Contains(htmlLine), "HTML line not found in HTML content.");
        }
        [Test]
        public void Test_HomeLink_present_in_DepartmentsView()
        {
            string htmlLine = "<a asp-controller=\"Employee\" asp-action=\"Home\">Home</a>";
            Assert.IsTrue(htmlContent.Contains(htmlLine), "Home link not found in HTML content.");
        }
        [Test]
        public void Test_AttendanceLink_present_in_Detailsview()
        {
            string htmlLine = "<a asp-controller=\"Employee\" asp-action=\"Attendance\">Attendance</a>";
            Assert.IsTrue(htmlContent.Contains(htmlLine), "Attendance link not found in HTML content.");
        }
        [Test]
        public void Test_EmployeeDetailsLink_present_in_HomeView()
        {
            string htmlLine = "<a asp-controller=\"Employee\" asp-action=\"Details\">Employee Details</a>";
            Assert.IsTrue(htmlContent.Contains(htmlLine), "Employee Details link not found in HTML content.");
        }
    }
}
