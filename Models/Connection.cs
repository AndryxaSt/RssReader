using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;



namespace RssReader.Models
{
    public class Connection
    {
        public IEnumerable<News> GetRss(string url)
        {
            List<News> news;

            XmlReader FeedReader = XmlReader.Create(url);
            SyndicationFeed Channel = SyndicationFeed.Load(FeedReader);

            if (Channel != null)
            {
                news = new List<News>();

                foreach (SyndicationItem RSI in Channel.Items)
                {
                    news.Add(new News()
                    {
                        Title = RSI.Title.Text,
                        ImgSrc = RSI.Links[1].Uri.AbsoluteUri,
                        Discription = RSI.Summary.Text,
                        Url = RSI.Id,
                        PubDate = RSI.PublishDate.DateTime
                    });

                }
                return news;
            }
            return new List<News>();
        }
    }
}
