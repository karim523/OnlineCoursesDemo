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
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");

            builder.Property(x => x.EndDate).IsRequired();


            builder.HasOne(s => s.Plan)
                  .WithMany()
                  .IsRequired();

        }
    }
}
