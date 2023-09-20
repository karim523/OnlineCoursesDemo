namespace Application.Courses.Dtos.CourseDtos
{
    public class DeleteCourseOutputDto
    {
        public Guid? DeletedCourseId { get;  set; }
        public List<string>? Erorrs { get; set; }
    
    }
}
