using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pup_Sup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Instantiate publishers, subscribers and PubSubService 
            IPublisher sportNewsPublisher = new NewsPublisher();
            IPublisher politicalNewsPublisher = new NewsPublisher();

            Subscriber sportSubscriber = new NewsSubscriber();
            Subscriber politicsSubscriber = new NewsSubscriber();
            Subscriber newsSubscriber = new NewsSubscriber();            
            

            //Declare Messages and Publish Messages to PubSubService
            Message sportMsg1 = new Message("Sport", "Sport news 1");
            Message sportMsg2 = new Message("Sport", "sport news 2");
            Message politicsMsg3 = new Message("Politics", "politics 1223");

            // 
            PubSubService pubSubService = new PubSubService();

            sportNewsPublisher.publish(sportMsg1, pubSubService);
            sportNewsPublisher.publish(sportMsg2, pubSubService);
            politicalNewsPublisher.publish(politicsMsg3, pubSubService);
                     

            
            //Declare Subscribers 
            sportSubscriber.AddSubscriber("Sport", pubSubService);
            politicsSubscriber.AddSubscriber("Politics", pubSubService);
            newsSubscriber.AddSubscriber("Sport", pubSubService);
            newsSubscriber.AddSubscriber("Politics", pubSubService);

            //Trying unSubscribing a subscriber
            //newsSubscriber.unSubscribe("Sport", pubSubService);

            //Broadcast message to all subscribers. After broadcast, messageQueue will be empty in PubSubService
            pubSubService.Broadcast();

            //Print messages of each subscriber to see which messages they got
            Console.WriteLine("Messages of Sport Subscriber are: ");
            sportSubscriber.printMessages();

            Console.WriteLine("\nMessages of Politics Subscriber are: ");
            politicsSubscriber.printMessages();

            Console.WriteLine("\nMessages of News Subscriber are: ");
            newsSubscriber.printMessages();

            Console.Write("\nPress Any Key:");
            Console.ReadKey();

        }
    }
}
