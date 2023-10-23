using SimpleObjects.ContentContext;
using SimpleObjects.SharedContext;
using System;

namespace SimpleObjects.SubscriptionContext
{
    public class WatchedLecture:Base,IEquatable<WatchedLecture>
    {
        private WatchedLecture()
        {
            
        }
        public WatchedLecture(Student student, Lecture lecture, DateTime watchedData)
        {
            Student = student;
            Lecture = lecture;
            WatchedDate = watchedData;
            
        }

        public Student Student { get; set; }
        public Lecture Lecture { get; set; }
        public DateTime WatchedDate { get; set; }

        public bool Equals(WatchedLecture other)
        {
            if(other is null) return false;
            return other.Student == Student && other.Lecture == Lecture && other.WatchedDate == WatchedDate;
        }
    }
}
