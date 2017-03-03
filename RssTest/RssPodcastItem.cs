using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssTest
{
    class RssPodcastItem
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public Uri Mp3 { get; set; }
        public DateTime Published { get; set; }
        // TODO: Implement duration
    }
}
