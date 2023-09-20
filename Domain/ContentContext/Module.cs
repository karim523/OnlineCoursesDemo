using System;
using System.Collections.Generic;
using System.Linq;
using SimpleObjects.ContentContext.Enums;
using SimpleObjects.NotificationContext;
using SimpleObjects.SharedContext;


namespace SimpleObjects.ContentContext
{
    
    public class Module : Base
    {
        private readonly List<Lecture> _lectures ;

        public Module(int order, string title)
        {
            SetOrder(order);
            SetTitle(title);
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
              
            var orderTitleLevelLecture = _lectures
                .Any(l => l.Order == lecture.Order||( l.Level == lecture.Level && l.Title == lecture.Title));
           
            if (orderTitleLevelLecture)
            {
                 return new Notification($"This Lecture of {lecture.Title}", "is found");
            }
            _lectures.Add(lecture);
            return null;
        }
        internal Notification DeleteLecture(Guid lectureId)
        {
            var lecture=_lectures.FirstOrDefault(l => l.Id == lectureId);
            if (lecture == null) 
            {
                return new Notification("Lecture","is not Found");
            }
            _lectures.Remove(lecture);
            return null;
        }
        internal Notification SetOrder(int order)
        {
            if (order < 0)
            {
                return new Notification("Order", $"is invaild");
            }
            Order = order;
            return null;
        }
        internal Notification SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length > 100)
            {
                return new Notification("Title", $"is invaild");
            }
            Title = title;
            return null;
        }
        internal bool IsLectureExist(int oreder,string title,EContentLevel level, Guid lectureId)
        {
            return _lectures
                   .Any(l => (l.Order == oreder || (l.Level == level && l.Title == title)) && l.Id != lectureId);
        }
    }
}