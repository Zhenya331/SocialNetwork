using SocialNetwork.Models;
using SocialNetwork.Repository.IRepository;
using SocialNetwork.Repository.RepositoryImplementation;
using SocialNetwork.Services.IServices;
using System.Threading.Tasks;

namespace SocialNetwork.Services.IServicesImplementation
{
    public class CheckServiceImplementation : ICheckService
    {
        private readonly IAccountChecks accountChecks;

        public CheckServiceImplementation(Social_networkContext context)
        {
            accountChecks = new AccountChecks(context);
        }

        public async Task<bool> IsMyFriend(long UserID, long FriendID)
        {
            return await accountChecks.IsMyFriend(UserID, FriendID);
        }

        public async Task<bool> IsMyRequestFriend(long UserID, long RequestFriendID)
        {
            return await accountChecks.IsMyRequestFriend(UserID, RequestFriendID);
        }
    }
}
