using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using System.Net;
using System.IO;

namespace RssPodcast
{
    class RssPodcast
    {
        private string RssFeed { get; set; }

        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public List<RssPodcastItem> Items { get; set; }

        public RssPodcast(string filename)
        {
            RssFeed = filename;
            Items = new List<RssPodcastItem>();
            create();
        }

        protected void create()
        {
            if (Items.Any())
                Items.Clear(); // Don't know wheater this make sence.

            XmlDocument doc = new XmlDocument();
            doc.Load(RssFeed); // HACK: Try-Catch

            Title = doc.SelectSingleNode("rss/channel/title").InnerText ?? "N/A";
            Link = new Uri(doc.SelectSingleNode("rss/channel/link").InnerText ?? "N/A");
            Description = doc.SelectSingleNode("rss/channel/description").InnerText ?? "N/A";
            Image = loadImage(doc.SelectSingleNode("rss/channel/image/url").InnerText);

            setUpItems(doc);
        }

        protected virtual void setUpItems(XmlDocument doc)
        {
            XmlNodeList nodes = doc.SelectNodes("rss/channel/item");

            foreach (XmlNode item in nodes)
            {
                Items.Add(
                    new RssPodcastItem()
                    {
                        Title = item.SelectSingleNode("title").InnerText ?? "N/A",
                        Description = item.SelectSingleNode("description").InnerText ?? "N/A",
                        Link = new Uri(item.SelectSingleNode("link").InnerText ?? ""),
                        Mp3 = new Uri(item.SelectSingleNode("enclosure").Attributes["url"].InnerText ?? "N/A"),
                        Published = DateTime.Parse(item.SelectSingleNode("pubDate").InnerText)
                    }
                    );
            }
        }

        protected Image loadImage(string url)
        {
            WebClient wc = new WebClient();
            byte[] ba = wc.DownloadData(url);
            MemoryStream ms = new MemoryStream(ba);
            return Image.FromStream(ms);
        }
    }
}
