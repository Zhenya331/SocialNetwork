using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public partial class RequestFriend
    {
        public long Id { get; set; }
        public long SendUserId { get; set; }
        public long RecieveUserId { get; set; }
        public DateTime DateSend { get; set; }

        public virtual User RecieveUser { get; set; }
        public virtual User SendUser { get; set; }
    }
}
