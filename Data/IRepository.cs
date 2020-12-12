using MVCCoreAngular.Data.Entities;
using System.Collections.Generic;

namespace MVCCoreAngular.Data
{
    public interface IRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductByCategory(string category);
        bool SaveChanges();
        Order GetOrderById(string userName, int id);
        void AddEntity(object model);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string userName, bool includeItems);
    }
}