using System;

namespace SocialNetwork.Models
{
    public partial class Message
    {
        public long Id { get; set; }
        public long SendId { get; set; }
        public long RecieveId { get; set; }
        public string MessageText { get; set; }
        public DateTime SendDate { get; set; }

        public virtual User Recieve { get; set; }
        public virtual User Send { get; set; }
    }
}
