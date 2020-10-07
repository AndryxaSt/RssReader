using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RssReader.Models
{
    public class News
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImgSrc { get; set; }
        public string Discription { get; set; }
        public DateTime PubDate { get; set; }
    }
}