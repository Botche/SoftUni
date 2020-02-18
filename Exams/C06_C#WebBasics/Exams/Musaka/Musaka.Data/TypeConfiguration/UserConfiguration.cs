using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musaka.Models;

namespace Musaka.Data.TypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(user => user.Receipts)
                .WithOne(receipt => receipt.Cashier)
                .HasForeignKey(receipt=>receipt.CashierId);

            builder
                .HasMany(user => user.Orders)
                .WithOne(order => order.Cashier)
                .HasForeignKey(order => order.CashierId);
        }
    }
}
