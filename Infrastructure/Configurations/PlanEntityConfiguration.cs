using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleObjects.SubscriptionContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class PlanEntityConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable("Plan");
         
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            
            builder.Property(x => x.Price).IsRequired();
            
        }
    }
}
