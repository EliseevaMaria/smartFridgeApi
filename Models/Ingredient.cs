namespace Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecieptId { get; set; }
        public int ProductId { get; set; }
        public float Amount { get; set; }
    }
}
