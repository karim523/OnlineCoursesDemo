using SimpleObjects.ContentContext.Enums;
using SimpleObjects.NotificationContext;
using SimpleObjects.SharedContext;
using System;

namespace SimpleObjects.ContentContext
{
    public class Lecture : Base
    {
        public Lecture(int order, string title, int durationInMinutes, EContentLevel level)
        {
            Order = order;
            Title = title;
            SetDuration(durationInMinutes);
            Level = level;
        }

        public int Order { get;private set; }
        public string Title { get;private set; }
        public int DurationInMinutes { get; private set; }
        public EContentLevel Level { get;private set; }
        private void SetDuration(int durationInMinutes)
        {

            if (IsDurationCorrect(durationInMinutes))
            {
                DurationInMinutes = durationInMinutes;
            }

            else
            {
                throw new Exception($"The Duration {durationInMinutes} is invalid");
            }
        }
        public void UpdateDuration(int durationInMinutes)
        {

            if (IsDurationCorrect(durationInMinutes))
            {
                DurationInMinutes = durationInMinutes;
            }

            else
            {
                AddNotification(new Notification($"The Duration In Minutes", $" Of Order Lecture {Order} is invalid"));
            }
        }
        bool IsDurationCorrect (int durationInMinutes)
        {
            return (durationInMinutes < 180 && durationInMinutes > 1);
        }

    }
}