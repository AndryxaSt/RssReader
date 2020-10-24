using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RssReader.Models
{
    public class EditModel
    {
        public string Name { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}