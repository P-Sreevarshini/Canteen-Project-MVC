using System;
using Microsoft.EntityFrameworkCore;


namespace dotnetapp.Models
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CanteenOrder> CanteenOrders { get; set; }
    }

}