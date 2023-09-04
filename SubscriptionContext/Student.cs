using System;
using System.Collections.Generic;
using System.Linq;
using SimpleObjects.NotificationContext;
using SimpleObjects.SharedContext;

namespace SimpleObjects.SubscriptionContext
{
    public class Student : Base
    {
        public User User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Subscription> Subscriptions { get; set; }
        public IList<WatchedLecture> WatchedLectures { get; set; }
        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);
        public void CreateSubscription(Subscription subscription)
        {
            if(IsPremium)
            {
                AddNotification(new Notification("Premiun","This Students already has an Active Subscription"));
                return;
            }
            Subscriptions.Add(subscription);
        }
        public void WatchLecture(WatchedLecture watchedLecture)
        {
            var IsWatched= WatchedLectures.Any(w=>w.Lecture==watchedLecture.Lecture);           
            if (IsWatched)
            {
                var oldWatchedLecture = WatchedLectures.First(x => x.Lecture == watchedLecture.Lecture);
                int result = DateTime.Compare(oldWatchedLecture.DateOfWatchingOfLect, watchedLecture.DateOfWatchingOfLect);
                if(result==0)
                {
                    return;
                }

                else if (result < 0)
                {
                    AddNotification(new Notification($"The Data:{watchedLecture.DateOfWatchingOfLect}"," is old"));
                    return;
                }

                else
                {
                    oldWatchedLecture.DateOfWatchingOfLect = watchedLecture.DateOfWatchingOfLect;
                    return;
                }

            }                
                WatchedLectures.Add(watchedLecture);
        }
    
    }
}