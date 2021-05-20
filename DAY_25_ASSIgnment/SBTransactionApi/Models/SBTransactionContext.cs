using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBTransactionApi.Models
{
    public class SBTransactionContext:DbContext
    {
        public SBTransactionContext() : base()
        {

        }
        public SBTransactionContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SBTransaction> SBTransactions  { get; set; }
    }
}
