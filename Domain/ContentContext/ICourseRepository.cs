using SimpleObjects.ContentContext;
using System;
using System.Threading.Tasks;

namespace Domain.ContentContext
{
    public interface ICourseRepository
    {
        Task<Course> GetCourse(Guid courseId);
    }
}
