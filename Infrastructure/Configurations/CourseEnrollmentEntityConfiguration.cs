using Domain.SubscriptionContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CourseEnrollmentEntityConfiguration : IEntityTypeConfiguration<CourseEnrollment>
    {
        public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
        {
            builder.ToTable("CourseEnrollment");


            builder.HasOne(w => w.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey("StudentId")
                .IsRequired();

            builder.HasOne(w => w.Course)
                .WithMany(c=>c.Students)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey("CourseId")
                .IsRequired();

        }
    }
}
