using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEg
{
    class EFContext : DbContext
    {
        public EFContext()
        {

        }
        private const string connectionString = @"server=DESKTOP-EBPUJ98\SQLEXPRESS;Integrated security=true;;Database=Day17DB;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }

    }

}

