using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleObjects.ContentContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configrations
{
    public class CourceEntityConfiguration:IEntityTypeConfiguration<Course>
    {     
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Tag).HasMaxLength(100);
            
            builder.Property(x => x.Url).IsRequired().HasMaxLength(256);

            builder.Property(x => x.Level).IsRequired();
           
            builder.Property(x => x.DurationInMinutes).IsRequired();

            builder.Ignore(x => x.Notifications);
        }
    }
}
