using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.CourseDtos
{
    public class StudentOutputDto
    {
        public Guid? StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentEmail { get; set; }
        public List<GetStudentCourseOutputDto>? Courses { get; set; }
        public string? Erorr { get; set; }
    }
    public class GetStudentCourseOutputDto
    {
        public Guid? CourseId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public EContentLevel? Level { get; set; }
        public string? Tag { get; set; }

    }
}
