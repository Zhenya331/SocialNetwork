using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.ViewModels
{
    public class ChatModel
    {
        public User user;
        public User friend;
        public List<Message> messages;
    }
}
