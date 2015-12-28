namespace Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public bool IsPrivate { get; set; }
        public string Type { get; set; }
    }
}
