﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class IngredientDTO
    {
        public int ReceiptId { get; set; }
        public Product Product { get; set; }
        public float Amount { get; set; }
        public string Measure { get; set; }
    }
}
