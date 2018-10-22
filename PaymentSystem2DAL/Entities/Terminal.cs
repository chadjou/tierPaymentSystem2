namespace PaymentSystem2DAL.Entities
{
    public class Terminal
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
    }
}