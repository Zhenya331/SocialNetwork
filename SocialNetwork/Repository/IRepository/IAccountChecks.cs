using System.Threading.Tasks;

namespace SocialNetwork.Repository.IRepository
{
    interface IAccountChecks
    {
        // Пользователь с id = FriendID - мой друг?
        public Task<bool> IsMyFriend(long UserID, long FriendID);

        // Пользователь с id = FriendID уже есть в моих заявках в друзья?
        public Task<bool> IsMyRequestFriend(long UserID, long RequestFriendID);
    }
}
