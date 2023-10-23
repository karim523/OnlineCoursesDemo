using SimpleObjects.ContentContext;
using SimpleObjects.SubscriptionContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.SubscriptionContext
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetStudent(Guid id);
        Task<Student> GetStudentCourses(Guid studentId);
    }
}
