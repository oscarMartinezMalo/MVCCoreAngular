using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using MVCCoreAngular.Data.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreAngular.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext ctx;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHostingEnvironment hosting;

        public Seeder(ApplicationDbContext _ctx,
            UserManager<IdentityUser> _userManager,
            IHostingEnvironment hosting)
        {
            ctx = _ctx;
            userManager = _userManager;
            this.hosting = hosting;
        }

        public async Task SeedAsync()
        {
            ctx.Database.EnsureCreated();

            IdentityUser user = await userManager.FindByNameAsync("asd@gmail.com");

            if (user == null)
            {
                user = new IdentityUser
                {
                    //FirstName = "Oscar",
                    //LastName = "Martinez",
                    Email = "omartinez@gmail.com",
                    UserName = "omartinez@gmail.com"
                };
            }

            var result = await userManager.CreateAsync(user, "P@ssw0rd!");
            if (result != IdentityResult.Success)
            {
                // throw new InvalidOperationException("Could not create new user in seeder");
            }

            if (!ctx.Products.Any())
            {
                // Need to create sample data
                var filePath = Path.Combine(hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                ctx.Products.AddRange(products);

                var order = ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };

                }

                ctx.SaveChanges();
            }
        }
    }
}
