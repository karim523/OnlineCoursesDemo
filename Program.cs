using System;
using SimpleObjects.ContentContext;

namespace SimpleObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var course = new Course();
            Console.WriteLine(course.Id.ToString());
        }
    }
}
