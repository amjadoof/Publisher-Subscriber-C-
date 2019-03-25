using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pup_Sup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pup_Sup.Tests
{
    [TestClass()]
    public class NewsSubscriberTests
    {
        [TestMethod()]
        public void AddSubscriberTest()
        {
            NewsSubscriber ns = new NewsSubscriber();
            PubSubService ps = new PubSubService();
            ns.AddSubscriber("Topic", ps);
            Assert.IsTrue(ps.subscribersTopicMap["Topic"].Contains(ns));
            ns.UnSubscribe("Topic", ps);
            Assert.IsFalse(ps.subscribersTopicMap["Topic"].Contains(ns));
        }

        [TestMethod()]
        public void GetMessagesForSubscriberOfTopicTest()
        {

        }

        [TestMethod()]
        public void UnSubscribeTest()
        {
            NewsSubscriber ns = new NewsSubscriber();
            PubSubService ps = new PubSubService();
            ns.AddSubscriber("Topic", ps);
            ns.UnSubscribe("Topic", ps);
            Assert.IsFalse(ps.subscribersTopicMap["Topic"].Contains(ns));
        }
    }
}