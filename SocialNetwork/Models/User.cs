using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public partial class User
    {
        public User()
        {
            FriendFriendNavigation = new HashSet<Friend>();
            FriendUser = new HashSet<Friend>();
            MessageRecieve = new HashSet<Message>();
            MessageSend = new HashSet<Message>();
            RequestFriendRecieveUser = new HashSet<RequestFriend>();
            RequestFriendSendUser = new HashSet<RequestFriend>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateRegistration { get; set; }

        public virtual ICollection<Friend> FriendFriendNavigation { get; set; }
        public virtual ICollection<Friend> FriendUser { get; set; }
        public virtual ICollection<Message> MessageRecieve { get; set; }
        public virtual ICollection<Message> MessageSend { get; set; }
        public virtual ICollection<RequestFriend> RequestFriendRecieveUser { get; set; }
        public virtual ICollection<RequestFriend> RequestFriendSendUser { get; set; }
    }
}
