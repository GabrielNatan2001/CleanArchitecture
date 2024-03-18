using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.Property(p => p.Image)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.HasOne(p => p.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
