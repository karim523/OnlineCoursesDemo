namespace Application.Courses.Dtos.LectureDtos
{
    public class DeleteLectureOutputDto
    {
        public Guid? DeletedLectureId { get; set; }
        public List<string>? Erorrs { get; set; }
      
    }
}
