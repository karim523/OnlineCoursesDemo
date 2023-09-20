namespace Application.Courses.Dtos.ModuleDtos
{
    public class UpdateModuleInputDto
    {
        public Guid CourseId { get; set; }
        public Guid ModuleId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
    }
}
