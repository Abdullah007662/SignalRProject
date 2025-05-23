﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalREntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public List<Basket>? Baskets { get; set; }

    }
}
