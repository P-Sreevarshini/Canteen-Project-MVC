using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using dotnetapp.Models;
using System.ComponentModel.DataAnnotations;
using static NuGet.Packaging.PackagingConstants;
using System.Numerics;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void Employee_Properties_Have_RequiredAttribute()
        {
            var count = 0;

            Type employeeType = typeof(Employee);
            PropertyInfo[] properties = employeeType.GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "Name")
                {
                    var requiredAttribute = property.GetCustomAttribute<RequiredAttribute>();
                    Assert.NotNull(requiredAttribute, $"{property.Name} should have a RequiredAttribute.");
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Employee_Properties_Have_EmailAddressAttribute()
        {
            var count = 0;
            Type employeeType = typeof(Employee);
            PropertyInfo[] properties = employeeType.GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "Email")
                {
                    var emailAttribute = property.GetCustomAttribute<EmailAddressAttribute>();
                    Assert.NotNull(emailAttribute, $"{property.Name} should have an EmailAddressAttribute.");
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                Assert.Fail();
            }
            
        }

        [Test]
        public void Employee_Properties_Have_RangeAttribute()
        {
            var count = 0;

            Type employeeType = typeof(Employee);
            PropertyInfo[] properties = employeeType.GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "Salary")
                {
                    var rangeAttribute = property.GetCustomAttribute<System.ComponentModel.DataAnnotations.RangeAttribute>();
                    Assert.NotNull(rangeAttribute, $"{property.Name} should have a RangeAttribute.");
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Employee_Properties_Have_DataTypeAttribute()
        {
            var count = 0;
            Type employeeType = typeof(Employee);
            PropertyInfo[] properties = employeeType.GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "Dob")
                {
                    var dataTypeAttribute = property.GetCustomAttribute<DataTypeAttribute>();
                    Assert.NotNull(dataTypeAttribute, $"{property.Name} should have a DataTypeAttribute.");
                    count++;
                    break;
                } 
            }
            if(count == 0)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Employee_Properties_Have_MinAgeAttribute()
        {
            var count = 0;
            Type employeeType = typeof(Employee);
            PropertyInfo[] properties = employeeType.GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "Dob")
                {
                    var minAgeAttribute = property.GetCustomAttribute<MinAgeAttribute>();
                    Assert.NotNull(minAgeAttribute, $"{property.Name} should have a MinAgeAttribute.");
                    count++;
                    break;
                }
            }
            if( count == 0)
            { Assert.Fail(); }
        }

        //[TestCase("Alice Brown", "alice@example.com", 1500, "1990-01-01", "HR", null)] // Valid case, no error expected
        [Test]
        public void Employee_Property_Name_Validation()
        {
            var employee1 = new Dictionary<string, object>
            {
                { "Name", "" },
                { "Email", "a@gmail.com" },
                { "Salary", 1500 },
                { "Dob", DateTime.Parse("1990-01-01") },
                { "Dept", "HR" }
            };
            var employee = CreatePlayerFromDictionary(employee1);
            string expectedErrorMessage = "Name is required";
            var context = new ValidationContext(employee, null, null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(employee, context, results);

            if (expectedErrorMessage == null)
            {
                Assert.IsTrue(isValid);
            }
            else
            {
                Assert.IsFalse(isValid);
                var errorMessages = results.Select(result => result.ErrorMessage).ToList();
                Assert.Contains(expectedErrorMessage, errorMessages);
            }
        }

        public Employee CreatePlayerFromDictionary(Dictionary<string, object> data)
        {
            var player = new Employee();
            foreach (var kvp in data)
            {
                var propertyInfo = typeof(Employee).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    if (propertyInfo.PropertyType == typeof(decimal) && kvp.Value is int intValue)
                    {
                        propertyInfo.SetValue(player, (decimal)intValue);
                    }
                    else
                    {
                        propertyInfo.SetValue(player, kvp.Value);
                    }
                }
            }
            return player;
        }


        [Test]
        public void Employee_Property_Email_Validation()
        {
           
            var employee1 = new Dictionary<string, object>
            {
                { "Name", "asd" },
                { "Email", "" },
                { "Salary", 1500 },
                { "Dob", DateTime.Parse("1990-01-01") },
                { "Dept", "HR" }
            };
            var employee = CreatePlayerFromDictionary(employee1);
            string expectedErrorMessage = "Email is required";
            var context = new ValidationContext(employee, null, null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(employee, context, results);

            if (expectedErrorMessage == null)
            {
                Assert.IsTrue(isValid);
            }
            else
            {
                Assert.IsFalse(isValid);
                var errorMessages = results.Select(result => result.ErrorMessage).ToList();
                Assert.Contains(expectedErrorMessage, errorMessages);
            }
        }
        [Test]
        public void Employee_Property_MinAge_Validation()
        {
            var employeeData = new Dictionary<string, object>
            {
                { "Name", "John Doe" },
                { "Email", "john@example.com" },
                { "Salary", 1500 },
                { "Dob", DateTime.Now.AddYears(-24).AddDays(1) }, // Adjusted to ensure below minimum age
                { "Dept", "HR" }
            };
            var employee = CreatePlayerFromDictionary(employeeData);
            string expectedErrorMessage = "Employee must be 25 years or older";
            var context = new ValidationContext(employee, null, null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(employee, context, results);

            if (expectedErrorMessage == null)
            {
                Assert.IsTrue(isValid);
            }
            
        }
        
        [Test]
public void Employee_UniqueEmail_ShouldPassValidation()
{
    // Mock employee data with unique email addresses for two employees
    var employee1Data = new Dictionary<string, object>
    {
        { "Name", "Jane Smith" },
        { "Email", "jane@example.com" },
        { "Salary", 2000 },
        { "Dob", DateTime.Parse("1990-05-15") },
        { "Dept", "IT" }
    };

    var employee2Data = new Dictionary<string, object>
    {
        { "Name", "James Brown" },
        { "Email", "jane@example.com" }, // Different email from employee1
        { "Salary", 1800 },
        { "Dob", DateTime.Parse("1985-03-10") },
        { "Dept", "Finance" }
    };

    // Create employee objects from the mock data
    var employee1 = CreatePlayerFromDictionary(employee1Data);
    var employee2 = CreatePlayerFromDictionary(employee2Data);

    // Validate the employee objects
    var context1 = new ValidationContext(employee1, null, null);
    var context2 = new ValidationContext(employee2, null, null);
    var results1 = new List<ValidationResult>();
    var results2 = new List<ValidationResult>();

    bool isValid1 = Validator.TryValidateObject(employee1, context1, results1);
    bool isValid2 = Validator.TryValidateObject(employee2, context2, results2);

    // Assert that both employees are valid
    Assert.IsTrue(isValid1);
    Assert.IsTrue(isValid2);
}

        private Employee CreateEmployeeFromDictionary(Dictionary<string, object> data)
        {
            var employee = new Employee();
            foreach (var kvp in data)
            {
                var propertyInfo = typeof(Employee).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    if (propertyInfo.PropertyType == typeof(decimal) && kvp.Value is int intValue)
                    {
                        propertyInfo.SetValue(employee, (decimal)intValue);
                    }
                    else
                    {
                        propertyInfo.SetValue(employee, kvp.Value);
                    }
                }
            }
            return employee;
        }
        [Test]
public void Employee_DuplicateEmail_ShouldFailValidation()
{
    var employee1Data = new Dictionary<string, object>
    {
        { "Name", "John Doe" },
        { "Email", "john@example.com" },
        { "Salary", 1500 },
        { "Dob", DateTime.Now.AddYears(-24).AddDays(1) }, // Adjusted to ensure above minimum age
        { "Dept", "HR" }
    };

    var employee2Data = new Dictionary<string, object>
    {
        { "Name", "Jane Smith" },
        { "Email", "john@example.com" }, // Same email as employee1
        { "Salary", 2000 },
        { "Dob", DateTime.Now.AddYears(-26).AddDays(1) }, // Adjusted to ensure above minimum age
        { "Dept", "IT" }
    };

    var employee1 = CreatePlayerFromDictionary(employee1Data);
    var employee2 = CreatePlayerFromDictionary(employee2Data);

    string expectedErrorMessage = "Email must be unique"; // Expected error message for duplicate email
    var context2 = new ValidationContext(employee2, null, null);
    var results2 = new List<ValidationResult>();

    bool isValid2 = Validator.TryValidateObject(employee2, context2, results2);

    Assert.IsFalse(isValid2);
    var errorMessages = results2.Select(result => result.ErrorMessage).ToList();
    Assert.Contains(expectedErrorMessage, errorMessages);

    // Assert that employee1 passes validation since the UniqueEmail attribute is commented out
    var context1 = new ValidationContext(employee1, null, null);
    var results1 = new List<ValidationResult>();
    bool isValid1 = Validator.TryValidateObject(employee1, context1, results1);
    Assert.IsTrue(isValid1);
}

    }
}
