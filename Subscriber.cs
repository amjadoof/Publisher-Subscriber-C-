using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pup_Sup
{
    abstract class Subscriber
    {
        //store all messages received by the subscriber
        public List<Message> SubscriberMessages { set; get; } = new List<Message>();        

        //Add subscriber with PubSubService for a topic
        public abstract void AddSubscriber(string Topic, PubSubService PubSubService);

        //Unsubscribe subscriber with PubSubService for a topic
        public abstract void UnSubscribe(string Topic, PubSubService PubSubService);

        //Request specifically for messages related to topic from PubSubService
        public abstract void GetMessagesForSubscriberOfTopic(string Topic, PubSubService pubSubService);

        //Print all messages received by the subscriber 
        public void printMessages()
        {
            foreach (Message message in SubscriberMessages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
