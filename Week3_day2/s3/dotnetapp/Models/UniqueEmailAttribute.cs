using System;
using System.ComponentModel.DataAnnotations;
using dotnetapp.Data;
using dotnetapp.Models;

namespace dotnetapp.Models
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var employee = validationContext.ObjectInstance as Employee;

            if (dbContext == null)
            {
                return new ValidationResult("Database context is not available.");
            }

            if (value == null)
            {
                return new ValidationResult("The email address is required.");
            }

            if (employee == null)
            {
                return new ValidationResult("Employee data is not available.");
            }

            if (dbContext.Employees != null && dbContext.Employees.Any(e => e.Email == value.ToString() && e.Id != employee.Id))
            {
                return new ValidationResult(ErrorMessage ?? "The email must be unique.");
            }

            return ValidationResult.Success;
        }
    }
    public class MinAgeAttribute : ValidationAttribute
    {
        private int _minAge;
        public MinAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateOfBirth = (DateTime)value;
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Now.AddYears(-age))
            {
                age--;
            }
            if (age < _minAge)
            {
                return new ValidationResult(this.ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}