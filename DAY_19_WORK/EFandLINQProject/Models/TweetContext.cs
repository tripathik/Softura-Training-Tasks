using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Models
{
    class TweetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-EBPUJ98\SQLEXPRESS;Integrated Security=true;Database=dbTweet");

            }
        }
        public DbSet<Post>Posts { get; set; }
        public DbSet<Comment>Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id=1,
                PostText="Test",
                Category="Info"
            });
        }
    }
}
