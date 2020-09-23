using System;

namespace SocialNetwork.Models
{
    public partial class Friend
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public DateTime AddFriendDate { get; set; }

        public virtual User FriendNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
