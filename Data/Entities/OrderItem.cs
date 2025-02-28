﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreAngular.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
