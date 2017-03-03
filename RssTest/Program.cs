using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;

namespace RssTest
{
    class Program
    {
        private static string site = "http://podcast-ufo.fail/?feed=podcast";
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            XmlDocument raw = new XmlDocument();
            raw.Load(site);

            XmlNode rssTitel = raw.SelectSingleNode("rss/channel/title");
            string title = rssTitel != null ? rssTitel.InnerText : "N/A";
            Console.WriteLine("Titel: " + title);


            RssPodcast pod = new RssPodcast(site);

            Console.ReadKey();
        }
    }
}
