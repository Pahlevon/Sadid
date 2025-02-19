using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SadidServices.Materials.Domain.Coils;

namespace SadidServices.Materials.Infrastructure.Persistence.Configurations
{
    //! This is A Config For EF Core To Interact With Database And Coil.
    public class CoilConfiguration : IEntityTypeConfiguration<Coil>  //This is How We Inject Entity Framework into Our Project
    {
        public void Configure(EntityTypeBuilder<Coil> builder)
        {
            builder.ToTable("Coils");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.Serial).HasMaxLength(100).IsRequired();
            builder.Property(c => c.SadidWeight).HasMaxLength(100).HasPrecision(8,0).IsRequired();
            builder.Property(c => c.Owner).HasMaxLength(100).IsUnicode().IsRequired();
            builder.Property(c => c.Type).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Size).HasMaxLength(100).HasPrecision(8,0).IsRequired();
            builder.Property(c => c.TimeReceive).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(250).IsRequired(false).IsUnicode();
            builder.Property(c=> c.Melt).IsRequired(false).HasPrecision(8,0);
            builder.Property(c=> c.OwnerWeight).IsRequired(false).HasPrecision(8,0);
          //? Other Properties







        }
    }
}