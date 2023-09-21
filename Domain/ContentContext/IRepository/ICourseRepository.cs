using SimpleObjects.ContentContext;
using SimpleObjects.ContentContext.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.ContentContext.IRepository
{
    public interface ICourseRepository
    {
        void Delete(Course course);
        Task<Course?> GetCourse(Guid courseId);
        Task<Lecture?> GetLecture(Guid lectureId);
        Task<Module?> GetModule(Guid moduleId);
        Task<List<Course>> GetAllCourse(string? title, EContentLevel? level);
    }
}
