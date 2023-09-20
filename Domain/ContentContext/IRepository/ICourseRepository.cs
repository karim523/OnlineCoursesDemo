using SimpleObjects.ContentContext;
using System;
using System.Threading.Tasks;

namespace Domain.ContentContext.IRepository
{
    public interface ICourseRepository
    {
        void Delete(Course course);
        void Update(Course course);

        Course GetCourse(Guid courseId);
    }
}
