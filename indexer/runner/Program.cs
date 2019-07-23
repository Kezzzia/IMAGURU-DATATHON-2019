using System.Linq;
using System.Globalization;
using System;
using System.IO;
using Nest;
using Newtonsoft.Json;

namespace runner
{
    partial class Program
    {
        public class CrawlersResult
        {
            public CrawlerEntry[] Entries { get; set; }
        }

        static void Main(string[] args)
        {
            var dataFolder = @"G:\src\hackatons\chaintrack\storage\decisions\";
            var crawlerIndex = @"G:\src\hackatons\chaintrack\storage\decisions\data.json";
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("documents").DisableDirectStreaming(true);
            var crawled = JsonConvert.DeserializeObject<CrawlersResult>(File.ReadAllText(crawlerIndex));


            var client = new Nest.ElasticClient(settings);
            var createIndexResponse = client.Indices.Create("documents", c => c
                                                                        .Settings(s => s

                                                                            .Analysis(a => a

                                                                                .TokenFilters(f => f
                                                                                    .Stemmer("russian_stemmer", st => st.Language("russian"))
                                                                                    .Stop("russian_stop", st => st.StopWords("_russian_"))
                                                                                )
                                                                                .Analyzers(aa => aa
                                                                                    .Custom("ru",
                                                                                        ca => ca
                                                                                        .Tokenizer("standard")
                                                                                        .Filters("russian_stop", "russian_stemmer")
                                                                                        // TODO: lowercase
                                                                                        )
                                                                                )
                                                                            )

                                                                        )
                                                                        .Map(x => x.AutoMap().Properties(pz => 
                                                                                pz.Text(tttt => tttt.Name("heading").Analyzer("ru"))
                                                                                .Text(tttt => tttt.Name("group").Analyzer("ru"))
                                                                                .Text(tttt => tttt.Name("name").Analyzer("ru"))
                                                                                .Text(tttt => tttt.Name("body").Analyzer("ru"))
                                                                                .Text(tttt => tttt.Name("institute").Analyzer("ru"))
                                                                                .Text(tttt => tttt.Name("reactionSlug").Analyzer("ru"))
                                                                                )
                                                                                )

                                                            );
            Console.WriteLine(createIndexResponse.DebugInformation);
            foreach (var c in crawled.Entries)
            {
                Console.WriteLine(c.name);

                var entry = new LawEntry();
                entry.group = c.group;
                entry.heading = c.heading;
                entry.name = c.name;
                entry.number = c.number;
                entry.body = File.ReadAllText(Path.Combine(dataFolder, c.textFile));
                entry.institute = c.institute;
                entry.publishedAt = DateTime.ParseExact(c.date, "dd.MM.yyyy", CultureInfo.CreateSpecificCulture("ru"));
                entry.reactionSlug = c.reactionSlug != null && c.reactionSlug.Any()? c.reactionSlug.Aggregate((acc, e) => acc + ", " + e) : null;
                Console.WriteLine("21312213 " + entry.reactionSlug);
                client.IndexDocument(entry);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
