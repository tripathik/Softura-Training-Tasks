using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAccountWebApi.Models
{
    public class SBAccountContext:DbContext
    {
        public SBAccountContext() : base()
        {

        }
        public SBAccountContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SBAccount> SBAccounts { get; set; }
    }
}
