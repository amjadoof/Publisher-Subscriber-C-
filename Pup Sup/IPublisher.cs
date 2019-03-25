using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pup_Sup
{
    public interface IPublisher
    {
        void publish(Message Message, PubSubService PubSubService);
    }
}
