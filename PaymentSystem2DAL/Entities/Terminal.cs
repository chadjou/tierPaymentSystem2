namespace PaymentSystem2DAL.Entities
{
    public class Terminal
    {
        public int TerminalId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
    }
}