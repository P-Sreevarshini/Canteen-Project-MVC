using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace dotnetapp.Models
{
    public class CanteenOrder
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Food Item is required")]
        public string FoodItem { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        public string SpecialInstructions { get; set; }

        public DateTime OrderDate { get; set; }
    }
}