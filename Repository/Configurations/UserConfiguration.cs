using De01_Enews.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace De01_Enews.Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Username).HasMaxLength(32);
        builder.Property(e => e.FullName).HasMaxLength(64);
        builder.Property(e => e.Phone).HasMaxLength(16);
        builder.Property(e => e.Email).HasMaxLength(64);
        builder.Property(e => e.Password).HasMaxLength(64);

        builder.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.RoleId);
        // builder.HasMany(e => e.ShoppingCartItems).WithOne(e => e.User).HasForeignKey(e => e.UserId);
        // builder.HasMany(e => e.Purchases).WithOne(e => e.User).HasForeignKey(e => e.UserId);
    }
}