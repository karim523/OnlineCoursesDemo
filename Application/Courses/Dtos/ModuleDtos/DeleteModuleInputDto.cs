namespace Application.Courses.Dtos.ModuleDtos
{
    public class DeleteModuleInputDto
    {
        public Guid CourseId { get; set; }
        public Guid ModuleId { get; set; }
    }
}