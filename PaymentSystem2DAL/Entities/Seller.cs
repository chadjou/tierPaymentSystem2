using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSystem2DAL.Entities
{
    public class Seller
    {
        public int SellerId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public List<Terminal> Terminals { get; set; }
    }
}
