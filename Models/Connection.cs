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
        public IEnumerable<Subscription> GetRss(string url)
        {
            List<Subscription> subscriptions;

            XmlReader FeedReader = XmlReader.Create(url);
            SyndicationFeed Channel = SyndicationFeed.Load(FeedReader);

            if (Channel != null)
            {
                subscriptions = new List<Subscription>();

                foreach (SyndicationItem RSI in Channel.Items)
                {
                    subscriptions.Add(new Subscription()
                    {
                        Title = RSI.Title.Text,
                        ImgSrc = RSI.Links[1].Uri.AbsoluteUri,
                        Discription = RSI.Summary.Text,
                        Url = RSI.Id,
                        PubDate = RSI.PublishDate.DateTime
                    });

                }
                return subscriptions;
            }
            return new List<Subscription>();
        }
    }
}
