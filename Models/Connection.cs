using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;

namespace RssReader.Models
{
    public class Connection
    {
        private string RemoveHtmlTags(string inputHtml)
        {
            inputHtml = inputHtml.Replace("<![CDATA[", "").Replace("]]>", "");

            inputHtml = Regex.Replace(inputHtml, "<.*?>", string.Empty).Replace("&nbsp;", string.Empty);

            return inputHtml;
        }
        public IEnumerable<IEnumerable<News>> GetRss(IEnumerable<Subscription> subscriptions)
        {
            List<List<News>> outputSubs = new List<List<News>>();
            List<News> news;

            if (subscriptions != null)
            {
                foreach (var subscription in subscriptions)
                {
                    news = new List<News>();
                    XmlReader FeedReader = XmlReader.Create(subscription.Url);
                    SyndicationFeed Channel = SyndicationFeed.Load(FeedReader);

                    if (Channel != null)
                    {
                        int indexImg = -1;


                        for (int i = 0; i < Channel.Items.First().Links.Count; i++)
                        {
                            if (Channel.Items.First().Links[i].MediaType == "image/jpeg")
                            {
                                indexImg = i;
                            }
                        }


                        foreach (SyndicationItem RSI in Channel.Items)
                        {
                            news.Add(new News()
                            {
                                SubsTitle = Channel.Title.Text,
                                Title = RSI.Title.Text,
                                ImgSrc = indexImg == -1 ? "Заглушка" : RSI.Links[indexImg].Uri.AbsoluteUri,
                                Discription = RemoveHtmlTags(RSI.Summary.Text),
                                Url = RSI.Id,
                                PubDate = RSI.PublishDate.DateTime
                            });
                        }

                        outputSubs.Add(news);
                    }
                }
                return outputSubs;
            }
            return outputSubs;
        }
    }
}
