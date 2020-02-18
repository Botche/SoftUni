using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musaka.Models;

namespace Musaka.Data.TypeConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(product => product.Orders)
                .WithOne(order => order.Product)
                .HasForeignKey(order => order.ProductId);
        }
    }
}
