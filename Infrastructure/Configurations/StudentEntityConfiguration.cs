using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleObjects.SubscriptionContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            
            builder.Ignore(x => x.Notifications);
        
            builder.HasOne(s => s.User)
                   .WithOne()
                   .HasForeignKey<Student>("UserId")
                   .HasPrincipalKey<User>(x=>x.Id)
                   .IsRequired();


            builder.HasMany(s=>s.Subscriptions)
                  .WithMany()
                  .UsingEntity("StudentSubscription");
        }
    }
}
