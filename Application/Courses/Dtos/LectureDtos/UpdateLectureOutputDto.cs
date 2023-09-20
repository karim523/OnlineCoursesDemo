namespace Application.Courses.Dtos.LectureDtos
{
    public class UpdateLectureOutputDto
    {
        public Guid? UpdatedLectureId { get; set; }
        public List<string>? Erorrs { get; set; }
       
    }
}
