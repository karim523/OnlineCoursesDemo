using SimpleObjects.ContentContext;
using SimpleObjects.SharedContext;
using SimpleObjects.SubscriptionContext;

namespace Domain.SubscriptionContext
{
    public class CourseEnrollment : Base
    {       
        public Course Course { get; set; }
        public Student Student { get; set; }
        private CourseEnrollment()
        {
        }
        internal CourseEnrollment(Course course, Student student)
        {
            Course = course;
            Student = student;
        }

    }
}
