using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.ModuleDtos
{
    public class GetModuleOutputDto
    {
        public Guid ModuleId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public List<GetModuleLectureDto>? Lectures { get; set; }
        public List<string>? Erorrs { get; set; }

    }
    public class GetModuleLectureDto
    {
        public Guid LectureId { get; set; }

        public int Order { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }

}

