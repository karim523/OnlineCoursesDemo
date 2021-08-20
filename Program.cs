using System;
using System.Collections.Generic;
using System.Linq;
using SimpleObjects.ContentContext;

namespace SimpleObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Article about OOP","orientation-object-programming"));
            articles.Add(new Article("Article about C#","csharp"));
            articles.Add(new Article("Article about .NET","net"));
            
            // foreach(var article in articles)
            // {
            //     Console.WriteLine(article.Id);
            //     Console.WriteLine(article.Title);
            //     Console.WriteLine(article.Url);
            // }

            var courses = new List<Course>();
            var courseOOP = new Course("Fundamentals of OOP", "fundamentals-of-oop");
            var courseCsharp = new Course("Fundamentals of C#", "fundamentals-of-csharp");
            var courseAspNet = new Course("Fundamentals of APS.NET", "fundamentals-of-asp-net");
            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

            var careers = new List<Career>();
            var careerDotnet = new Career(".NET expert","dotnet-expert");
            var careerItem1 = new CareerItem(1,"Start Here", "", courseCsharp);
            var careerItem2 = new CareerItem(2,"Learn OOP", "", courseOOP);
            var careerItem3 = new CareerItem(3,"Learn .NET", "", null);
            careerDotnet.Items.Add(careerItem2);
            careerDotnet.Items.Add(careerItem3);
            careerDotnet.Items.Add(careerItem1);
            careers.Add(careerDotnet);

            foreach(var career in careers)
            {
                Console.WriteLine(career.Title);
                foreach(var item in career.Items.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine($"{item.Course?.Title}");
                    Console.WriteLine($"{item.Course?.Level}");

                    foreach(var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
            }
        }
    }
}
