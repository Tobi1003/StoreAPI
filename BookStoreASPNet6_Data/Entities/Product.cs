using System;
using System.Collections.Generic;

namespace BookStoreASPNet6_Data.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? TypeId { get; set; }
    }
}
