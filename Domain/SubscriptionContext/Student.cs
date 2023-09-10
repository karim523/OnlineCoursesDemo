using System;
using System.Collections.Generic;
using System.Linq;
using Domain.SharedContext;
using SimpleObjects.NotificationContext;
using SimpleObjects.SharedContext;

namespace SimpleObjects.SubscriptionContext
{
    public class Student : Base,IEntity
    {
        public User User { get; private set; }
        public string Name { get;private set; }
        public string Email { get;private set; }
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
                int result = DateTime.Compare(oldWatchedLecture.WatchedDate, watchedLecture.WatchedDate);
                if(result==0)
                {
                    return;
                }

                else if (result < 0)
                {
                    AddNotification(new Notification($"The Data:{watchedLecture.WatchedDate}"," is old"));
                    return;
                }

                else
                {
                    oldWatchedLecture.WatchedDate = watchedLecture.WatchedDate;
                    return;
                }

            }                
                WatchedLectures.Add(watchedLecture);
        }
    public static Student SignUp(string name,string email,User user) 
        {
            var student=new Student();
            student.SetName(name);
            student.SetEmail(email);
            student.SetUser(user);
            return student;
        }
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Invalid Name");

            if (!(name.Length >= 3 && name.Length <= 150)) throw new ArgumentException("Invalid Name");
            Name = name;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("Invalid Email");
            Email = email;
        }

        private void SetUser(User user) 
        {
            if (user == null) throw new ArgumentNullException("user invaild");
            User = user;
        }

    }
}