﻿using SimpleObjects.ContentContext.Enums;

namespace Application.Courses.Dtos.LectureDtos
{
    public class UpdateLectureInputDto
    {
        public Guid CourseId { get; set; }
        public Guid ModuleId { get; set; }
        public Guid LectureId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get;  set; }

    }
}
