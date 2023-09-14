using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleObjects.ContentContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ModuleEntityConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("Module");

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Order).IsRequired();
            

            builder.HasOne<Course>()
                  .WithMany(c=>c.Modules)
                  .IsRequired();
        }


    }
}
