using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCCoreAngular.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MVCCoreAngular.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext ctx;
        private readonly ILogger<Repository> logger;

        // **Orders API**
        public Repository(ApplicationDbContext ctx, ILogger<Repository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {

            if (includeItems)
            {
                return ctx.Orders.Include(o => o.Items)
                                .ThenInclude(i => i.Product)
                                .ToList();
            }
            else
            {
                return ctx.Orders.ToList();
            }

        }


        public IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems)
        {
            if (includeItems)
            {
                return ctx.Orders
                    .Where(o => o.User.UserName == userName)
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .ToList();
            }
            else
            {
                return ctx.Orders.ToList();
            }
        }

        public Order GetOrderById(string userName, int id)
        {
            return ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.Id == id && o.User.UserName == userName)
                .FirstOrDefault();
        }

        // **Products API**
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return ctx.Products
                     .OrderBy(p => p.Title)
                     .ToList();
            }
            catch (System.Exception ex)
            {
                logger.LogInformation($"Failed to GetAllProducts {ex}");
                return null;
            }

        }


        public IEnumerable<Product> GetProductByCategory(string category)
        {
            return ctx.Products
                .Where(p => p.Category == category)
                 .OrderBy(p => p.Title)
                 .ToList();
        }

        public void AddEntity(object model)
        {
            ctx.Add(model);

        }

        public bool SaveChanges()
        {
            return ctx.SaveChanges() > 0;
        }

    }
}
