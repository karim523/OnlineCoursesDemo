using System;
using System.Collections.Generic;

namespace SimpleObjects.ContentContext
{
    public class Career : Content
    {
        public Career()
        {
            Items = new List<CareerItem>();
        }
        public IList<CareerItem> Items { get; set; }
        public int CoursesCount => Items.Count;
        
    }
    
}