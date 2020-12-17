﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image_Url { get; set; }
    }
}
