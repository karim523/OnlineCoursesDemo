using System;
using SimpleObjects.NotificationContext;
using SimpleObjects.SharedContext;

namespace SimpleObjects.ContentContext
{
    public class CareerItem : Base
    {
        private CareerItem() { }
        public CareerItem(int order, string title, string description, Course course)
        {
            if(course == null)            
               throw new Exception("Course Invalid course");
            Order = order;
            Title = title;
            Description = description;
            Course = course;
        }

        public int Order {get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
    }
}