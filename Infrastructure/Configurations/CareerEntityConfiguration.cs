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
    public class CareerEntityConfiguration : IEntityTypeConfiguration<Career>
    {
        public void Configure(EntityTypeBuilder<Career> builder)
        {
            builder.ToTable("Career");

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Url).IsRequired().HasMaxLength(256);

            builder.Ignore(x => x.Notifications);
        }
    }
}
