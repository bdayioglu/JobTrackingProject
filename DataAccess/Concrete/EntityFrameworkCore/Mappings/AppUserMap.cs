using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Surname).HasMaxLength(100);

            builder.HasMany(I => I.Gorevler).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
