using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem2.ViewModels
{
    public class SellerVm
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public List<TerminalVm> Terminals { get; set; }
    }
}
