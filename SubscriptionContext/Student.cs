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
        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);
        public void CreateSubscription(Subscription subscription)
        {
            if(IsPremium)
            {
                AddNotification(new Notification("Premiun","This Students already have an Active Subscription"));
                return;
            }
            Subscriptions.Add(subscription);
        }
    }
}