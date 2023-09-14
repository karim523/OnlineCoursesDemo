using Domain.ContentContext;
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
        public Task<Course> GetCourse(Guid courseId)
        {
            return _dbContext.Courses
                .Include(c => c.Modules)
                .ThenInclude(x => x.Lectures)
                .FirstOrDefaultAsync(x => x.Id == courseId);
        }

    }
}
