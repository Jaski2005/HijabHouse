using HijabHouse.Models;

namespace HijabHouse.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Dresses.AddRange(
                    new Dress
                    {
                        Name = "Fustan Elegant",
                        Price = 35,
                        Description = "Fustan elegant dhe modest për raste speciale.",
                        Material = "chanel",
                        Sizes = "S, M, L, XL",
                        Color = "Roze",
                        ImageUrl = "/images/fustani1.jpg"
                    },

                    new Dress
                    {
                        Name = "Fustan Minimal",
                        Price = 35,
                        Description = "Dizajn modern, i thjeshtë dhe modest",
                        Material = "Kadife",
                        Sizes = "S, M, L",
                        Color = "E kuqe",
                        ImageUrl = "/images/fustani2.jpg"  
                    },
                    new Dress
                    {
                        Name = "Fustan Evening",
                        Price = 35,
                        Description = "Fustan elegant për evente dhe mbrëmje",
                        Material = "Krep",
                        Sizes = "S, M, L, XL",
                        Color = "Lejla",
                        ImageUrl = "/images/fustani3.jpg"
                    }
                );
                        //KRIJIMI I ADMINIT
        if (!context.User.Any(u => u.Email == "admin@hijabhouse.com"))
        {
            context.User.Add(new User
            {
                 Name = "Admin",
                 Email = "admin@hijabhouse.com",
                 Password = "Admin123!",
                 IsAdmin = true
            });


            context.SaveChanges();
        }

    }
    }
}