using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    [Table("Orders")]
    public class Order
    {
        [Required]
        public int OrderID { get; set; }

        [Required]
        [StringRange(AllowableValues = new[] { "Recieved", "Completed", "Cancelled" }, ErrorMessage = "Must be Recieved, Completed or Cancelled only")]
        public string OrderStatus { get; set; }

        [Required]
        [StringRange(AllowableValues = new[] { "Shipped", "Rejected" }, ErrorMessage = "Must be Shipped or Rejected only")]
        public string ShippingStatus { get; set; }
    }
}