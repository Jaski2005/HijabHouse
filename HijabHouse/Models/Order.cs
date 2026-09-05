using System.ComponentModel.DataAnnotations;

namespace HijabHouse.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Phone { get; set; } = "";
        [Required]
        public string Addresa { get; set; } = "";
        [Required]
        public string City { get; set; } = "";
        [Required]
        public string PaymentMethod { get; set; } = "";
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}