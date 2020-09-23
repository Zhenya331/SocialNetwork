using SocialNetwork.Models;
using SocialNetwork.Repository.IRepository;
using SocialNetwork.Repository.RepositoryImplementation;
using SocialNetwork.Services.IServices;
using System.Threading.Tasks;

namespace SocialNetwork.Services.IServicesImplementation
{
    public class ActionServiceImplementation : IActionService
    {
        private readonly IAccountActions accountActions;

        public ActionServiceImplementation(Social_networkContext context)
        {
            accountActions = new AccountActions(context);
        }

        public async void AcceptRequestFriend(long UserID, long RequestFriendID)
        {
            await Task.Run(() => accountActions.AcceptRequestFriend(UserID, RequestFriendID));
        }

        public async void AddMessage(long UserID, long FriendID, string Message)
        {
            await Task.Run(() => accountActions.AddMessage(UserID, FriendID, Message));
        }

        public async void CancelRequestFriend(long UserID, long RequestFriendID)
        {
            await Task.Run(() => accountActions.CancelRequestFriend(UserID, RequestFriendID));
        }

        public async void DeleteFriend(long UserID, long FriendID)
        {
            await Task.Run(() => accountActions.DeleteFriend(UserID, FriendID));
        }

        public async void DeleteRequestFriend(long UserID, long RequestFriendID)
        {
            await Task.Run(() => accountActions.DeleteRequestFriend(UserID, RequestFriendID));
        }

        public async void SendRequestFriend(long UserID, long RequestFriendID)
        {
            await Task.Run(() => accountActions.SendRequestFriend(UserID, RequestFriendID));
        }
    }
}
