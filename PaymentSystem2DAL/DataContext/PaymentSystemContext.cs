using PaymentSystem2DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PaymentSystem2DAL.DataContext
{
    public  class PaymentSystemContext : DbContext
    {
        public PaymentSystemContext(DbContextOptions<PaymentSystemContext> options) : base(options)
        { }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
    }
}
