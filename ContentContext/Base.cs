using System;
using SimpleObjects.NotificationContext;

namespace SimpleObjects.ContentContext
{
    public abstract class Base : Notifiable
    {
        public Guid Id { get; set; }
        public Base()
        {
            Id = Guid.NewGuid();
        }
    }
}