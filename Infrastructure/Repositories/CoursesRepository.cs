using Domain.ContentContext.IRepository;
using Microsoft.EntityFrameworkCore;
using SimpleObjects.ContentContext;
using SimpleObjects.ContentContext.Enums;
using SimpleObjects.SubscriptionContext;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDBContext _dbContext;

        public CourseRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  Task<Course?> GetCourse(Guid courseId)
        {
            return  _dbContext.Courses
                .Include(c => c.Modules)
                .ThenInclude(x => x.Lectures)
                .FirstOrDefaultAsync(x => x.Id == courseId);
        }
        public Task <Module?> GetModule(Guid moduleId) 
        {
            return _dbContext.Modules
                .Include(m=>m.Lectures)
                .FirstOrDefaultAsync (m => m.Id == moduleId);
        }
        public Task<Lecture?> GetLecture(Guid lectureId)
        {
            return _dbContext.Lectures
                .FirstOrDefaultAsync(l => l.Id == lectureId);
        }
        public void Delete(Course course)
        {            
              _dbContext.Courses.Remove(course);           
        }

        public Task<List<Course>> GetAllCourse(string? title,EContentLevel? level)
        {
            return _dbContext.Courses
                   .Where(c => title == null || c.Title.Contains(title))
                   .Where(c=> level == null || c.Level == level)
                   .Include(c => c.Modules)
                   .ThenInclude(m => m.Lectures)
                   .ToListAsync();
 
        }

        public async Task<Course?> GetCourseStudents(Guid courseId)
        {
            return await _dbContext.Courses
                .Include(c => c.Students)
                .ThenInclude(s => s.Student)
                .FirstOrDefaultAsync(x => x.Id == courseId);
        }
    }
}   
            
