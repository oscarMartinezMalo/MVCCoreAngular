using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MVCCoreAngular.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public IdentityUser User { get; set; }
    }
}
