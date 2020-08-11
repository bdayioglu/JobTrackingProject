using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class AciliyetMap : IEntityTypeConfiguration<Aciliyet>
    {
        public void Configure(EntityTypeBuilder<Aciliyet> builder)
        {
            builder.Property(I => I.Tanim).HasMaxLength(100);
        }
    }
}
