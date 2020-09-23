using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.ViewModels
{
    public class FriendsListModel
    {
        public readonly User user;
        public readonly List<User> friends;

        public FriendsListModel(User user, List<User> friends)
        {
            this.user = user;
            this.friends = friends;
        }
    }
}
