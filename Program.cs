using System;
using System.Collections.Generic;
using SimpleObjects.ContentContext;

namespace SimpleObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP","orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#","csharp"));
            articles.Add(new Article("Artigo sobre .NET","net"));
            
            foreach(var article in articles)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            }
        }
    }
}
