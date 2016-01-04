using System;

namespace Models
{
    public class FridgeProductDTO
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public float Amount { get; set; }
        public DateTime DateMade { get; set; }
        public float MinAmount { get; set; }
    }
}
