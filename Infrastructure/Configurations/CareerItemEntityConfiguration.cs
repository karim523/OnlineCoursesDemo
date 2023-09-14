using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleObjects.ContentContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class CareerItemEntityConfiguration : IEntityTypeConfiguration<CareerItem>
    {
        public void Configure(EntityTypeBuilder<CareerItem> builder)
        {
           builder.ToTable("CareerItem");

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            
            builder.Property(x => x.Order).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(512);
            
            builder.HasOne(c=>c.Course)
                .WithMany()
                .IsRequired();
            
            builder.HasOne<Career>()
                .WithMany(x=>x.Items)
                .IsRequired();
        }
    }
}
