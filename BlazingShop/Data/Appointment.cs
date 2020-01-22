using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingShop.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public DateTime AppointmentDate { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [MaxLength(12)]
        [MinLength(5)]
        //[RegularExpression("^[0-9]$", ErrorMessage = "Phone Number must be at least 6 Digits Long.")]
        public string CustomerPhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public bool IsConfirmed { get; set; } 
    }
}
