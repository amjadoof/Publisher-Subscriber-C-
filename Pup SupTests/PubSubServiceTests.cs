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
    public class PubSubServiceTests
    {
        [TestMethod()]
        public void AddMessageToQueueTest()
        {
            PubSubService ps = new PubSubService();
            ps.AddMessageToQueue(new Message("Data", "Scince"));
            Assert.AreEqual(ps.messagesQueue.Count, 1);
            ps.messagesQueue.Dequeue();
            Assert.AreEqual(ps.messagesQueue.Count, 0);
        }

        [TestMethod()]
        public void AddSubscriberTest()
        {
            PubSubService ps = new PubSubService();
            NewsSubscriber ns = new NewsSubscriber();
            ps.AddSubscriber("Topic", ns);
            Assert.IsTrue(ps.subscribersTopicMap["Topic"].Contains(ns));
        }

        [TestMethod()]
        public void RemoveSubscriberTest()
        {

        }

        [TestMethod()]
        public void BroadcastTest()
        {

        }

        [TestMethod()]
        public void GetMessagesForSubscriberOfTopicTest()
        {

        }
    }
}