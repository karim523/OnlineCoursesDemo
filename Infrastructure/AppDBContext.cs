using Infrastructure.Configrations;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleObjects.ContentContext;
using SimpleObjects.NotificationContext;
using SimpleObjects.SharedContext;
using SimpleObjects.SubscriptionContext;
using System;

namespace Infrastructure
{
    public class AppDBContext :DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<CareerItem> CareerItems { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<WatchedLecture> WatchedLectures { get; set; }
       
    }
    
}
