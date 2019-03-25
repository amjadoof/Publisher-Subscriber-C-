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
    public class MessageTests
    {
        [TestMethod()]
        public void MessageTest()
        {
            Message m = new Message("News", "Content");
            Assert.AreEqual(m.Topic, "News");
            Assert.AreEqual(m.Description, "Content");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Message m = new Message("News", "Content");
            Assert.AreEqual(m.ToString(), "[Topic:News, Description:Content]");
        }
    }
}