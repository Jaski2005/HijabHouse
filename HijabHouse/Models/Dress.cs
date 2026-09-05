namespace HijabHouse.Models
{
    public class Dress
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public string Material { get; set; } = "";
        public string Sizes { get; set; } = "";
        public string Color { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}