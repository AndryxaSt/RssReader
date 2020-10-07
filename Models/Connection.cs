using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;
using System.Net;



namespace RssReader.Models
{
    public class Connection
    {
        public Subscription.Rss Deserialize(string url)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Subscription.Rss));
            Subscription.Rss newItem;

            WebRequest request = WebRequest.Create(url);

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    newItem = (Subscription.Rss)formatter.Deserialize(response.GetResponseStream());
                    return newItem;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Subscription.Rss> Deserialize(List<Subscription> subscriptions)
        {
            List<Subscription.Rss> RssList = new List<Subscription.Rss>();

            foreach (var subscription in subscriptions)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Subscription.Rss));
                Subscription.Rss newItem;

                WebRequest request = WebRequest.Create(subscription.Url);

                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        newItem = (Subscription.Rss)formatter.Deserialize(response.GetResponseStream());
                        RssList.Add(newItem);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return RssList;
            
        }

    }


}