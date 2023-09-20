namespace Application.Courses.Dtos.ModuleDtos
{
    public  class DeleteModuleOutputDto
    {
        public Guid? DeletedModuleId { get; set; }
        public List<string>? Erorrs { get; set; }
     
    }
}
