namespace Application.Courses.Dtos.LectureDtos
{
    public class DeleteLectureInputDto
    {
        public Guid CourseId { get; set; }
        public Guid ModuleId { get; set; }
        public Guid LectureId { get; set; }
    }
}
