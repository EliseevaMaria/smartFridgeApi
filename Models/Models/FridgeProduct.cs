using System;

namespace Models
{
    public class FridgeProduct
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public int ProductId { get; set; }
        public float Amount { get; set; }
        public DateTime DateMade { get; set; }
        public float MinAmount { get; set; }
    }
}
