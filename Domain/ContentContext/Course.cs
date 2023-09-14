using System;
using System.Collections.Generic;
using System.Linq;
using Domain.SharedContext;
using SimpleObjects.ContentContext.Enums;
using SimpleObjects.NotificationContext;

namespace SimpleObjects.ContentContext
{
   
    public class Course : Notifiable,IEntity
    {
        private readonly List<Module> _modules;

        public Course(string title, string url, EContentLevel level, string tag)            
        {
            Title = title;
            Url = url;
            _modules = new List<Module>();
            Level = level;
            Tag = tag;
        }

        public string Title { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
        public IReadOnlyList<Module> Modules
        {
            get
            {
                return this._modules.AsReadOnly();
            }
        } 
        public int DurationInMinutes { get;private set; }
        public EContentLevel Level { get;private set; }
        public bool AddModule(Module module)
        {
            var titleAndOrderModule= _modules.Any(m=>m.Title == module.Title|| m.Order == module.Order);

            if (titleAndOrderModule)
            {
                AddNotification(new Notification($"This Module of {module.Title}", " is found"));
                return false;
            }
            _modules.Add(module);
            CalculateDuration();
            return true;
        }
        public bool AddLecture(Guid moduleId , Lecture lecture)
        {
           var module =_modules.FirstOrDefault(x=>x.Id == moduleId);
       
            if (module == null)
            {
                AddNotification(new Notification($"This Module", " is not found"));
                return false;
            }
            
            module.AddLecture(lecture);
           
            CalculateDuration();
            return true;
        } 
        public bool AddLecture(int order, Lecture lecture)
        {
             var module =_modules.FirstOrDefault(x=>x.Order == order);
                  
             var result = module.AddLecture(lecture);
            
            if (result == null)
            {
                CalculateDuration();
                
                return true;
            }
            AddNotification(result);
            return false;
        }
        private void CalculateDuration()
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