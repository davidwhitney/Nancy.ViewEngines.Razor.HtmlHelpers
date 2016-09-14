using System;
using System.Collections.Generic;
using Nancy.Hosting.Self;

namespace Nancy.ViewEngines.Razor.HtmlHelpersUnofficial.TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nancyHost = new NancyHost(
                new HostConfiguration {UrlReservations = new UrlReservations {CreateAutomatically = true}},
                new Uri("http://localhost:1447"));

            nancyHost.Start();

            Console.WriteLine("Hosting on localhost:1447");
            Console.ReadKey();
        }
    }

    public class HomeModule : NancyModule
    {
        public HomeModule() : base("/")
        {
            Get["/"] = x => View["index.cshtml", new Model()];
        }
    }

    public class Model
    {
        public int AnInt { get; set; }
        public List<string> ListOfStrings { get; set; }
        public string AString { get; set; }
        public IEnumerable<int> EnumerableInts { get; set; }
        public int? NullableInt { get; set; }
        public bool ABool { get; set; }

        public Model()
        {
            AnInt = 123;
            ListOfStrings = new List<string> { "a", "b" };
            AString = "lol";
            EnumerableInts = new[] { 1 };
            NullableInt = 123;
        }
    }
}
