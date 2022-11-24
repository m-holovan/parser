using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace RegularExpressions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var config = Configuration.Default.WithDefaultLoader();
            using var context = BrowsingContext.New(config);
            Console.WriteLine("*Choose group*");
            Console.WriteLine("For example(535v)");
            Console.Write("Your choice:");
            string group = Console.ReadLine();

            var url = "https://education.khai.edu/union/schedule/group/" + group;

            using var doc = await context.OpenAsync(url);
            var title = doc.Title;

            Console.WriteLine(title);

            var pars1 = doc.QuerySelectorAll("tr");

            foreach (var par in pars1)
            {
                Console.WriteLine(par.Text().Trim());
            }
        }
    }
}
