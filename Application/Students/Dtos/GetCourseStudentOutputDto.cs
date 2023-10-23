using SimpleObjects.ContentContext.Enums;

namespace Application.Students.Dtos
{
   
    public class CourseOutputDto
    {
        public Guid? CourseId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public EContentLevel? Level { get; set; }
        public string? Tag { get; set; }
        public List<GetCourseStudentOutputDto>? Students {  get; set; }
        public string? Erorr { get; set; }
    }
    public class GetCourseStudentOutputDto
    {
        public Guid? StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentEmail { get; set; }
    }
}
