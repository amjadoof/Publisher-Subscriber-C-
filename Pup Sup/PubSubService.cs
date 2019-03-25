using System;
using System.Collections.Generic;

namespace Pup_Sup
{
    public class PubSubService
    {
        //Keeps set of subscriber topic wise, using set to prevent duplicates 
        public Dictionary<string, HashSet<Subscriber>> subscribersTopicMap { get; private set; } = new Dictionary<string, HashSet<Subscriber>>();

        //Holds messages published by publishers
        public Queue<Message> messagesQueue { set; get; } = new Queue<Message>();

        //Adds message sent by publisher to queue
        public void AddMessageToQueue(Message message)
        {
            messagesQueue.Enqueue(message);
        }

        public void AddSubscriber(string topic, NewsSubscriber subscriber)
        {
            if (subscribersTopicMap.ContainsKey(topic))
            {
                HashSet<Subscriber> subscribers = subscribersTopicMap[topic];
                subscribers.Add(subscriber);
                subscribersTopicMap[topic] = subscribers;
            }
            else
            {
                HashSet<Subscriber> subscribers = new HashSet<Subscriber>();
                subscribers.Add(subscriber);
                subscribersTopicMap.Add(topic, subscribers);
            }
        }

        public void RemoveSubscriber(string topic, NewsSubscriber subscriber)
        {
            if (subscribersTopicMap.ContainsKey(topic))
            {
                HashSet<Subscriber> subscribers = subscribersTopicMap[topic];
                subscribers.Remove(subscriber);
                subscribersTopicMap[topic] = subscribers;
            }
        }

        //Broadcast new messages added in queue to All subscribers of the topic. messagesQueue will be empty after broadcasting
        public void Broadcast()
        {
            if (messagesQueue.Count ==0)
            {
                Console.WriteLine("No messages from publishers to display");
            }
            else
            {
                while (messagesQueue.Count != 0)
                {
                    Message message = messagesQueue.Dequeue();
                    String topic = message.Topic;

                    HashSet<Subscriber> subscribersOfTopic = subscribersTopicMap[topic];

                    foreach (Subscriber subscriber in subscribersOfTopic)
                    {
                        //add broadcasted message to subscribers message queue
                        List<Message> subscriberMessages = subscriber.SubscriberMessages;
                        subscriberMessages.Add(message);
                        subscriber.SubscriberMessages = subscriberMessages;
                    }
                }
            }
        }

        public void GetMessagesForSubscriberOfTopic(string topic, NewsSubscriber subscriber)
        {
            if (messagesQueue.Count == 0)
            {
                Console.WriteLine("No messages from publishers to display");
            }
            else
            {
                while (messagesQueue.Count != 0)
                {
                    Message message = messagesQueue.Dequeue();

                    if (message.Topic.ToLower().Equals(topic.ToLower()))
                    {

                        HashSet<Subscriber> subscribersOfTopic = subscribersTopicMap[topic];

                        foreach (Subscriber _subscriber in subscribersOfTopic)
                        {
                            if (_subscriber.Equals(subscriber))
                            {
                                //add broadcasted message to subscriber message queue
                                List<Message> subscriberMessages = subscriber.SubscriberMessages;
                                subscriberMessages.Add(message);
                                subscriber.SubscriberMessages = subscriberMessages;
                            }
                        }
                    }
                }
            }
        }
    }
}