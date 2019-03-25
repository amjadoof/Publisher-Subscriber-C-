using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pup_Sup
{
    public class NewsPublisher : IPublisher
    {
        public void publish(Message Message, PubSubService PubSubService)
        {
            PubSubService.AddMessageToQueue(Message);
        }
    }
}
