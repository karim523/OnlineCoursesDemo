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
    public class LectureEntityConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.ToTable("Lecture");

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
           
            builder.Property(x => x.Level).IsRequired();

            builder.Property(x => x.Order).IsRequired();

            builder.Property(x => x.DurationInMinutes).IsRequired();
            
            builder.HasOne<Module>()
               .WithMany(m=>m.Lectures)
               .IsRequired();
        }
    }
}
