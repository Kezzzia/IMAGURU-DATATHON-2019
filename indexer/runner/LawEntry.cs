using System;
using Nest;

namespace runner
{
    partial class Program
    {
        public class LawEntry
        {
            [Date]
            public DateTime publishedAt {get;set;}
            public string body { get; set; }
            public string name { get; set; }
            public string group { get; set; }
            public string heading { get; set; }

            public string institute {get;set;}

            public string originalUrl{get;set;}

            public string number {get;set;}

            public string reactionSlug {get;set;}
        }
    }
}
