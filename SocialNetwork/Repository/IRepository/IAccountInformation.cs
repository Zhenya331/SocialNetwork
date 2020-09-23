using SocialNetwork.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.IRepository
{
    interface IAccountInformation
    {
        // Получить профиль пользователя
        public Task<User> GetUserProfile(long UserID);

        // Получить список пользователей по имени
        public Task<List<User>> GetUsersList(string UserName);

        // Получить список друзей пользователя
        public Task<List<User>> GetFriendsList(long UserID);

        // Получить список входящий заявок в друзья
        public Task<List<User>> GetFriendRequestsIncomingList(long UserID);

        // Получить список исходящих заявок в друзья
        public Task<List<User>> GetFriendRequestsOutgoingList(long UserID);

        // Получить id пользователя по его имени
        public Task<long?> GetUserID(string UserName);


        // Получить список сообщений между текущим пользователем и его другом
        public Task<List<Message>> GetMessagesList(long UserID, long FriendID);
    }
}
