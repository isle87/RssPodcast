using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;

namespace RssPodcast
{
    class Program
    {
        private static string site = "http://www.pietsmiet.de/pietcast/feed/podcast/";
        static void Main(string[] args)
        {
            RssPodcast pod = new RssPodcast(site);
            Console.WriteLine("Title: " + pod.Title);

            foreach (RssPodcastItem item in pod.Items)
            {
                if (item.Published <= new DateTime(2017, 1, 1))
                    continue;
                Console.WriteLine(new string('-',10));
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
