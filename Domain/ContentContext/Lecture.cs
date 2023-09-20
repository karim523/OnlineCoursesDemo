using SimpleObjects.ContentContext.Enums;
using SimpleObjects.NotificationContext;
using SimpleObjects.SharedContext;

namespace SimpleObjects.ContentContext
{
    public class Lecture : Base
    {
        public Lecture(int order, string title, int durationInMinutes, EContentLevel level)
        {
            SetOrder(order);
            SetTitle(title);
            SetDuration(durationInMinutes);
            SetLevel(level);
        }

        public int Order { get;private set; }
        public string Title { get;private set; }
        public int DurationInMinutes { get; private set; }
        public EContentLevel Level { get;private set; }
        internal Notification UpdateDuration(int durationInMinutes)
        {
            if (IsDurationCorrect(durationInMinutes))
            {
                DurationInMinutes = durationInMinutes;
                return null;
            }
                return new Notification($"The Duration In Minutes", $" Of Order Lecture {Order} is invalid");                 
        }
        private  bool IsDurationCorrect (int durationInMinutes)
        {
            return (durationInMinutes < 180 && durationInMinutes > 1);
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
        internal Notification SetLevel(EContentLevel level)
        {
            Level= level;
            return null;
        }
        internal Notification SetDuration(int durationInMinutes)
        {
            if (IsDurationCorrect(durationInMinutes))
            {
                DurationInMinutes = durationInMinutes;
            }
            else
            {
                return new Notification($"The Duration {durationInMinutes}", " is invalid");
            }
            return null;
        }
    }
}