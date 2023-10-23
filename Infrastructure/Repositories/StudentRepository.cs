using Domain.SubscriptionContext;
using Microsoft.EntityFrameworkCore;
using SimpleObjects.ContentContext;
using SimpleObjects.SubscriptionContext;

namespace Infrastructure.Repositories
{
    public class StudentRepository: IStudentRepository
    {

        private readonly AppDBContext _appDBContext;
        public StudentRepository( AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<List<Student>> GetAll()
        {
            return await  _appDBContext.Students.ToListAsync();
        }

        public async Task<Student?> GetStudent (Guid id)
        {
            return  await _appDBContext.Students.Include(c=>c.Courses).FirstOrDefaultAsync(s => s.Id == id);
        }

    
        public async Task<Student?> GetStudentCourses(Guid studentId)
        {
            return await _appDBContext.Students
                .Include(s => s.Courses)
                .ThenInclude(c=>c.Course)
                .FirstOrDefaultAsync(x => x.Id == studentId);
                
        }
    }
}
