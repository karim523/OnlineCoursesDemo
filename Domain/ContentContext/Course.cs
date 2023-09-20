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
            SetTitle(title);
            SetUrl(url);
            _modules = new List<Module>();
            SetLevel(level);
            SetTag(tag);
        }

        public string Title { get; private set; }
        public string Url { get;private set; }
        public string Tag { get; private set; }
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
     
        public bool DeleteModule(Guid moduleId)
        {
            var module =_modules.FirstOrDefault (x=>x.Id == moduleId);
            
            if (module == null)
            {
                AddNotification(new Notification($"This Module", " is not found"));
                return false;
            }
            _modules.Remove(module);
            
            CalculateDuration();
            
            return true;
        }
        public bool DeleteLecture(Guid moduleId, Guid lectureId)
        {
            var module=_modules.FirstOrDefault(x=>x.Id == moduleId);
            if (module == null)
            {
                AddNotification(new Notification("Module", "is not Found"));
                return false;
            }
           
            var result= module.DeleteLecture(lectureId);

            if (result == null)
            {
                CalculateDuration();

                return true;
            }
            AddNotification(result);
            return false;

        }

        public bool UpdateModule(Guid moduleId, int order, string title)
        {
            var module = _modules.FirstOrDefault(x => x.Id == moduleId);

            if (module == null)
            {
                AddNotification(new Notification("Module", "is not Found"));
                return false;
            }
            var isModuleExist = _modules.Any(m => (m.Title == title || m.Order == order) && m.Id != moduleId);

            if (isModuleExist)
            {
                AddNotification(new Notification($"This Module of {title} ", "is exist"));
                return false;
            }
            var setTitleResult = module.SetTitle(title);     
           
            if (setTitleResult != null)
            {
                AddNotification(setTitleResult);
                return false; 
            }
            var setOrderResult = module.SetOrder(order);
            if (setOrderResult != null)
            {
                AddNotification(setOrderResult);
                return false;
            }
            return true;
        }
        public bool UpdateCourse( string url, EContentLevel level, string title, string tag)
        {
            if (SetTag(tag) && SetTitle(title) && SetUrl(url) && SetLevel(level) )
            {
                return true;
            }
            return false;          
        }
        public bool UpdateLecture(Guid ModuleId, Guid LectureId, string title, EContentLevel level, int order, int durationInMinutes)
        {
            var module = _modules.FirstOrDefault(m => m.Id == ModuleId);
           
            if (module == null) 
            {
                AddNotification(new Notification("Module", "is not Found"));
                return false;
            }

            var lecture = module.Lectures.FirstOrDefault(m => m.Id == LectureId);
            
            if(lecture == null)
            {
                AddNotification(new Notification("Lecture", "is not Found"));
                return false;
            }           

            if (module.IsLectureExist(order,title,level,LectureId))
            {
                AddNotification( new Notification($"This Lecture of {title}", "is exist"));
                return false;
            }
         
            var setDurationResult = lecture.SetDuration(durationInMinutes);
           
            if (setDurationResult != null)
            {
                AddNotification(setDurationResult);
                return false;
            }
            
            var setTitleResult=lecture.SetTitle(title);
            
            if (setTitleResult != null)
            {
                AddNotification(setTitleResult);
                return false;
            }
            
            var setLevelResult=lecture.SetLevel(level);
            
            if (setLevelResult != null)
            {
                AddNotification(setLevelResult);
                return false;
            }
            var setOrderResult=lecture.SetOrder(order);
            
            if (setOrderResult != null)
            {
                AddNotification(setOrderResult);
                return false;
            }
              
            CalculateDuration();
            
            return true;     
        }
        
        private void CalculateDuration()
        {
            DurationInMinutes = _modules.Sum(m => m.Lectures.Sum(l => l.DurationInMinutes));

        }
        
        private bool SetTag(string tag)
        {
            if (tag is not null && tag.Length > 100)
            {
                AddNotification(new Notification($"Tag: {tag} ", "is invaild"));        
                return false;
            }
            Tag = tag;
            return true;

        }
        private bool SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length > 100) 
            {
                AddNotification(new Notification($"Title : {title} ","is invaild"));
                return false;
            }
            Title = title;
            return true;
        }
        private bool SetUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url) || url.Length > 256) 
            {
                AddNotification(new Notification($"Url :{url} ", "is invaild"));
                return false;
            }
            Url = url;
            return true;
        }
        private bool SetLevel(EContentLevel level)
        {
            Level = level;
            return true;
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