using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssPodcast
{
    class RssPodcastItem
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public Uri Mp3 { get; set; }
        public DateTime Published { get; set; }
        // TODO: Implement duration

        public override string ToString()
        {
            return String.Format("Titel {0}\nDescription: {1}\nPublished: {2}", Title, Description, Published.ToString());
        }
    }
}
