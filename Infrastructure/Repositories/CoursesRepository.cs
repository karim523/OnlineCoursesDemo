using Domain.ContentContext.IRepository;
using Microsoft.EntityFrameworkCore;
using SimpleObjects.ContentContext;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDBContext _dbContext;

        public CourseRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Course GetCourse(Guid courseId)
        {
            return _dbContext.Courses
                .Include(c => c.Modules)
                .ThenInclude(x => x.Lectures)
                .FirstOrDefault(x => x.Id == courseId);
        }
        public void Delete(Course course)
        {            
                _dbContext.Courses.Remove(course);
            
        }

        public void Update(Course course)
        {
             _dbContext.Courses.Update(course);
        }
    }
}
