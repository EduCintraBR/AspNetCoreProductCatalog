using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;

namespace ProductCatalog.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(100).HasColumnType("varchar(120)").IsRequired();
            builder.Property(x => x.Price).HasColumnType("money").IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(1024).HasColumnType("varchar(1024)").IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.LastUpdateDate).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1024).HasColumnType("varchar(1024)").IsRequired();

            builder.HasOne(x => x.Category).WithMany(x => x.Products);
        }
    }
}
