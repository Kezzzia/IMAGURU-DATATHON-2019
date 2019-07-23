using System;
using System.Collections.Generic;

namespace runner
{
    partial class Program
    {
        public class CrawlerEntry
        {
            public string id { get; set; }
            public string group { get; set; }
            public string originalUrl { get; set; }
            public string textFile { get; set; }
            public string date { get; set; }
            public string name { get; set; }

            public string number {get;set;}

            public string institute { get; set; }
            public string heading {get;set;}

            public List<string> reactionSlug{get;set;} = new List<string>();

            internal bool Any()
            {
                throw new NotImplementedException();
            }
        }
    }
}
