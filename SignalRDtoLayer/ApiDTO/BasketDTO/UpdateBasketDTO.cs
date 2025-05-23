﻿using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.ApiDTO.BasketDTO
{
    public class UpdateBasketDTO
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public int MenuTableID { get; set; }
        public MenuTable? MenuTable { get; set; }
    }
}
