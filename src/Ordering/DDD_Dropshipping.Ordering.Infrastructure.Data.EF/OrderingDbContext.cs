using DDD_Dropshipping.Ordering.Infrastructure.Data.EF.Order;
using Microsoft.EntityFrameworkCore;

namespace DDD_Dropshipping.Ordering.Infrastructure.Data.EF
{
    public class OrderingDbContext : DbContext
    {
        public DbSet<Domain.OrderAggregate.Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DDD_Dropshipping;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEFMapping());
        }

    }
}
