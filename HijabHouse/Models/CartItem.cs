namespace HijabHouse.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int DressId { get; set; }
        public Dress Dress { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int Quantity { get; set; }
    }
}