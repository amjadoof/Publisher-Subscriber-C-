namespace Pup_Sup
{
    public class Message
    {
        public string Description { get; internal set; }
        public string Topic { get; internal set; }

        public Message(string topic, string description)
        {
            Topic = topic;
            Description = description;
        }

        public override string ToString()
        {
            return string.Format("[Topic:{0}, Description:{1}]", Topic, Description);
        }
    }
}