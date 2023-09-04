using System;
using System.Collections.Generic;
using System.Linq;
using SimpleObjects.ContentContext;
using SimpleObjects.SubscriptionContext;

namespace SimpleObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //var articles = new List<Article>();
            //articles.Add(new Article("Article about OOP","orientation-object-programming"));
            //articles.Add(new Article("Article about C#","csharp"));
            //articles.Add(new Article("Article about .NET","net"));
            
            //// foreach(var article in articles)
            //// {
            ////     Console.WriteLine(article.Id);
            ////     Console.WriteLine(article.Title);
            ////     Console.WriteLine(article.Url);
            //// }

            //var courses = new List<Course>();
            //var courseOOP = new Course(1,"Fundamentals of OOP", "fundamentals-of-oop");
            //var courseCsharp = new Course(2, "Fundamentals of C#", "fundamentals-of-csharp");
            //var courseAspNet = new Course(3, "Fundamentals of APS.NET", "fundamentals-of-asp-net");
            //courses.Add(courseOOP);
            //courses.Add(courseCsharp);
            //courses.Add(courseAspNet);

            //var careers = new List<Career>();
            //var careerDotnet = new Career(".NET expert","dotnet-expert");
            //var careerItem1 = new CareerItem("Start Here", "", courseCsharp);
            //var careerItem2 = new CareerItem("Learn OOP", "", courseOOP);
            //var careerItem3 = new CareerItem("Learn .NET", "", null);
            //careerDotnet.Items.Add(careerItem2);
            //careerDotnet.Items.Add(careerItem3);
            //careerDotnet.Items.Add(careerItem1);
            //careers.Add(careerDotnet);

            //foreach(var career in careers)
            //{
            //    Console.WriteLine(career.Title);
            //    foreach(var item in career.Items.OrderBy(x => x.Order))
            //    {
            //        Console.WriteLine($"{item.Order} - {item.Title}");
            //        Console.WriteLine($"{item.Course?.Title}");
            //        Console.WriteLine($"{item.Course?.Level}");

            //        foreach(var notification in item.Notifications)
            //        {
            //            Console.WriteLine($"{notification.Property} - {notification.Message}");
            //        }
            //    }
            //}   
       
            var student1 = new Student { Name = "Karim",Email="Karim@gmail.com" };
            var student2 = new Student { Name = "Ahmed", Email = "Ahmed@gmail.com" };
            
            var lecture1 = new Lecture {  Title = "Programming" ,DurationInMinutes = 150 };
            var lecture2 = new Lecture {  Title = "Data Structures", DurationInMinutes = 100};
            var lecture3 = new Lecture {  Title = "OOP", DurationInMinutes = 130};

            student1.WatchedLectures = new List<WatchedLecture>
            {
                new WatchedLecture(student1,lecture1,new DateTime(2022,1,1,10,15,0)),
                new WatchedLecture(student1,lecture3,new DateTime(2022, 2, 5, 9, 0, 0)),
                new WatchedLecture(student1,lecture2,new DateTime(2022,1,5,8,0,0))
            };

            student2.WatchedLectures = new List<WatchedLecture>
            {
                  new WatchedLecture(student2,lecture2,new DateTime(2022,1,1,10,15,0))
            };

            var watchedLecture = new WatchedLecture(student1, lecture2, new DateTime(2022, 1, 5, 9,0 , 0));
 

            student1.WatchLecture(watchedLecture);

            var watchedLectures = student1.WatchedLectures.Select( sl => new { sl.Lecture.Title,sl.DateOfWatchingOfLect}).ToList();
            foreach (var lecture in watchedLectures)
            {
                Console.WriteLine( lecture );
            } 
           
        }
    }
}
