using backapi.Models;
using Microsoft.EntityFrameworkCore;

namespace backapi.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Products> ObjectProduct {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(Auto => Auto.ID);
                entity.ToTable("Shopping_stock");

                entity.Property(Auto => Auto.ID)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Product_name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Description)
                .HasMaxLength(50);

                entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .IsRequired();

                entity.Property(e => e.Stock_remain)
                .IsRequired();

                entity.Property(e => e.Modified_Date)
                .IsRequired();

                entity.Property(e => e.Remark)
                .HasMaxLength(50);

            }

            );
        }
    }
}
