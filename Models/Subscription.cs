using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace RssReader.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImgSrc { get; set; }
        public string Discription { get; set; }
        public DateTime PubDate { get; set; }
        public List<User> Users { get; set; }
        public Subscription()
        {
            Users = new List<User>();
        }
    }
}