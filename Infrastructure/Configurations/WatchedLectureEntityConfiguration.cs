using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleObjects.ContentContext;
using SimpleObjects.SubscriptionContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class WatchedLectureEntityConfiguration : IEntityTypeConfiguration<WatchedLecture>
    {
        public void Configure(EntityTypeBuilder<WatchedLecture> builder)
        {
            builder.ToTable("WatchedLecture");

            builder.Property(x => x.WatchedDate).IsRequired();
            
            
            builder.HasOne(w=>w.Student)
                .WithMany(s => s.WatchedLectures)
                .HasForeignKey("StudentId")
                .IsRequired();

            builder.HasOne(w=>w.Lecture)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey("LectureId")
                .IsRequired();

        }
    }
}
