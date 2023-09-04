using SimpleObjects.ContentContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleObjects.SubscriptionContext
{
    public class WatchedLecture:IEquatable<WatchedLecture>
    {
        public WatchedLecture(Student student, Lecture lecture, DateTime dateOfWatchingOfLect)
        {
            Student = student;
            Lecture = lecture;
            DateOfWatchingOfLect = dateOfWatchingOfLect;
            
        }

        public Student Student { get; set; }
        public Lecture Lecture { get; set; }
        public DateTime DateOfWatchingOfLect { get; set; }

        public bool Equals(WatchedLecture other)
        {
            if(other is null) return false;
            return other.Student == Student && other.Lecture == Lecture && other.DateOfWatchingOfLect == DateOfWatchingOfLect;
        }
    }
}
