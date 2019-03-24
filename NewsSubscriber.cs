using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pup_Sup
{
    class NewsSubscriber : Subscriber
    {
        //Add subscriber with PubSubService for a topic
        public override void AddSubscriber(string Topic, PubSubService PubSubService)
        {
            PubSubService.AddSubscriber(Topic, this);
        }

        //Request specifically for messages related to topic from PubSubService
        public override void GetMessagesForSubscriberOfTopic(string Topic, PubSubService PubSubService)
        {
            PubSubService.GetMessagesForSubscriberOfTopic(Topic, this);
        }

        //Unsubscribe subscriber with PubSubService for a topic
        public override void UnSubscribe(string Topic, PubSubService PubSubService)
        {
            PubSubService.RemoveSubscriber(Topic, this);
        }
    }
}
