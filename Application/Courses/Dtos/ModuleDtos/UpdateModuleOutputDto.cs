namespace Application.Courses.Dtos.ModuleDtos
{
    public class UpdateModuleOutputDto
    {
        public Guid? UpdatedModuleId { get; set; }

        public List<string>? Erorrs { get; set; }
    }
}
