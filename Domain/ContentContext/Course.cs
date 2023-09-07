using System;
using System.Collections.Generic;
using System.Linq;
using SimpleObjects.ContentContext.Enums;
using SimpleObjects.NotificationContext;

namespace SimpleObjects.ContentContext
{
    public class Course : Content
    {
        private readonly List<Module> _modules;
      
        public Course(string title, string url )
            :base(title,url)
        {
            _modules = new List<Module>();
        }

        public string Tag { get; set; }
        public IReadOnlyList<Module> Modules
        {
            get
            {
                return this._modules.AsReadOnly();
            }
        }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
        public void AddModule(Module module)
        {
            var titleAndOrderModule= _modules.Any(m=>m.Title == module.Title|| m.Order == module.Order);

            if (titleAndOrderModule)
            {
                AddNotification(new Notification($"This Module", " is here"));
                return;
            }
            _modules.Add(module);
            CalculateDuration();
        }
        void CalculateDuration()
        {
            DurationInMinutes = _modules.Sum(m => m.Lectures.Sum(l => l.DurationInMinutes));

        }
        public override string ToString()
        {
            Console.Write( $"Title Course : {Title} - Url Course:{Url} - Duration In Minutes Of Course: {DurationInMinutes} - \n\n\t Modules :");
            foreach (var item in Modules)
            {
                Console.Write($" Order Module: {item.Order} - Title Module:{item.Title} - \n\n\t lectures : ");
                foreach (var lecture in item.Lectures)
                {
                    Console.WriteLine($"\t Order Lecture: {lecture.Order} - Title Lecture : {lecture.Title} - Duration In Minutes of Lecture : {lecture.DurationInMinutes}");
                }
            }
            return $"";
        }

    }
}