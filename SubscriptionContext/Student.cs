using SimpleObjects.SharedContext;

namespace SimpleObjects.SubscriptionContext
{
    public class Student : Base
    {
        public User User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}