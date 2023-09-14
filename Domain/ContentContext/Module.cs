using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Domain.SharedContext;
using SimpleObjects.NotificationContext;
using SimpleObjects.SharedContext;


namespace SimpleObjects.ContentContext
{
    
    public class Module : Base
    {
        private readonly List<Lecture> _lectures ;

        public Module(int order, string title)
        {
            Order = order;
            Title = title;
            _lectures = new List<Lecture>(); 
        }

        public int Order { get;private set; }
        public string Title { get;private set; }
        public IReadOnlyList<Lecture> Lectures
        {
            get
            {
                return this._lectures.AsReadOnly();
            }

        } 

        internal Notification AddLecture(Lecture lecture)
        {
              
            var orderTitleLevelLecture = _lectures.Any(l => l.Order == lecture.Order||( l.Level == lecture.Level && l.Title == lecture.Title));
            if (orderTitleLevelLecture)
            {
                 return new Notification($"This Lecture", "is here");
            }
            _lectures.Add(lecture);
            return null;
        }
    }
}