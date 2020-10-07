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
        public List<User> Users { get; set; }
        public Subscription()
        {
            Users = new List<User>();
        }

        [XmlRoot(ElementName = "image")]

        public class Image
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
            [XmlElement(ElementName = "link")]
            public string Link { get; set; }
            [XmlElement(ElementName = "url")]
            public string Url { get; set; }
        }

        [XmlRoot(ElementName = "guid")]
        public class Guid
        {
            [XmlAttribute(AttributeName = "isPermaLink")]
            public string IsPermaLink { get; set; }
            [XmlText]
            public string Text { get; set; }
        }

        [XmlRoot(ElementName = "enclosure")]
        public class Enclosure
        {
            [XmlAttribute(AttributeName = "length")]
            public string Length { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "url")]
            public string Url { get; set; }
        }

        [XmlRoot(ElementName = "item")]
        public class Item
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
            [XmlElement(ElementName = "link")]
            public string Link { get; set; }
            [XmlElement(ElementName = "description")]
            public string Description { get; set; }
            [XmlElement(ElementName = "pubDate")]
            public string PubDate { get; set; }
            [XmlElement(ElementName = "guid")]
            public Guid Guid { get; set; }
            [XmlElement(ElementName = "enclosure")]
            public Enclosure Enclosure { get; set; }
        }

        [XmlRoot(ElementName = "channel")]
        public class Channel
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
            [XmlElement(ElementName = "link")]
            public string Link { get; set; }
            [XmlElement(ElementName = "language")]
            public string Language { get; set; }
            [XmlElement(ElementName = "image")]
            public Image Image { get; set; }
            [XmlElement(ElementName = "lastBuildDate")]
            public string LastBuildDate { get; set; }
            [XmlElement(ElementName = "pubDate")]
            public string PubDate { get; set; }
            [XmlElement(ElementName = "item")]
            public List<Item> Item { get; set; }
        }

        [XmlRoot(ElementName = "rss")]

        public class Rss
        {
            [XmlElement(ElementName = "channel")]
            public Channel Channel { get; set; }
            [XmlAttribute(AttributeName = "version")]
            public string Version { get; set; }

        }
    }
}