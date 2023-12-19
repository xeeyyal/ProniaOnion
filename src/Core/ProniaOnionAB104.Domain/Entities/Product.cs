﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAB104.Domain.Entities
{
    public class Product:BaseNameableEntity
    {
        public decimal Price { get; set; }
        public string SKU { get; set; } = null!;
        public string? Description { get; set; }

        //Relational  properties
        public int  CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<ProductColor>? ProductColors { get; set; }
    }
}
