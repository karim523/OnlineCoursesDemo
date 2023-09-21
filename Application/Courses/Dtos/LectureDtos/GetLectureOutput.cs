
using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.LectureDtos
{
    public class GetLectureOutputDto
    {
        public Guid? LectureId { get; set; }
        public int? Order { get; set; }
        public string? Title { get; set; }
        public int? DurationInMinutes { get; set; }
        public EContentLevel? Level { get; set; }
        public List<string>? Erorrs { get; set; }

    }
}
