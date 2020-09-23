

namespace SocialNetwork.Repository.IRepository
{
    interface IAccountActions
    {
        //Отклонить входящую заявку в друзья
        public void DeleteRequestFriend(long UserID, long RequestFriendID);

        //Принять входящую заявку в друзья
        public void AcceptRequestFriend(long UserID, long RequestFriendID);

        //Удалить друга
        public void DeleteFriend(long UserID, long FriendID);

        //Отправить пользователю заявку в друзья
        public void SendRequestFriend(long UserID, long RequestFriendID);

        //Отменить отправленную пользователю заявку в друзья
        public void CancelRequestFriend(long UserID, long RequestFriendID);

        //Добавить сообщение в бд
        public void AddMessage(long UserID, long FriendID, string Message);
    }
}
