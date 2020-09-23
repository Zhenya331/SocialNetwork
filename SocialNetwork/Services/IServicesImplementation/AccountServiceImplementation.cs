using SocialNetwork.Models;
using SocialNetwork.Repository.IRepository;
using SocialNetwork.Repository.RepositoryImplementation;
using SocialNetwork.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.IServicesImplementation
{
    public class AccountServiceImplementation : IAccountService
    {
        private readonly IAccountInformation accountInformation;

        public AccountServiceImplementation(Social_networkContext context)
        {
            accountInformation = new AccountInformation(context);
        }

        public async Task<List<User>> GetFriendRequestsIncomingList(long UserID)
        {
            return await accountInformation.GetFriendRequestsIncomingList(UserID);
        }

        public async Task<List<User>> GetFriendRequestsOutgoingList(long UserID)
        {
            return await accountInformation.GetFriendRequestsOutgoingList(UserID);
        }

        public async Task<List<User>> GetFriendsList(long UserID)
        {
            return await accountInformation.GetFriendsList(UserID);
        }

        public async Task<List<Message>> GetMessagesList(long UserID, long FriendID)
        {
            return await accountInformation.GetMessagesList(UserID, FriendID);
        }

        public async Task<long?> GetUserID(string UserName)
        {
            return await accountInformation.GetUserID(UserName);
        }

        public async Task<User> GetUserProfile(long UserID)
        {
            return await accountInformation.GetUserProfile(UserID);
        }

        public async Task<List<User>> GetUsersList(string UserName)
        {
            return await accountInformation.GetUsersList(UserName);
        }
    }
}
