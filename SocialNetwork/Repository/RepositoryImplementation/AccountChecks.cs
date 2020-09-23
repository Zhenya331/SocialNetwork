using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;
using SocialNetwork.Repository.IRepository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.RepositoryImplementation
{
    public class AccountChecks : IAccountChecks
    {
        protected readonly Social_networkContext context;

        public AccountChecks(Social_networkContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsMyFriend(long UserID, long FriendID)
        {
            try
            {
                Friend friend = await context.Friend
                                             .FirstOrDefaultAsync(p => (p.UserId == UserID && p.FriendId == FriendID)
                                                                    || (p.UserId == FriendID && p.FriendId == UserID));
                return friend != null;
            }
            catch(Exception ex)
            {
                string message = ex.ToString();
                return false;
            }
        }

        public async Task<bool> IsMyRequestFriend(long UserID, long RequestFriendID)
        {
            try
            {
                RequestFriend requestFriend = await context.RequestFriend
                                                           .FirstOrDefaultAsync(p => (p.SendUserId == RequestFriendID && p.RecieveUserId == UserID)
                                                                                  || (p.SendUserId == UserID && p.RecieveUserId == RequestFriendID));
                return requestFriend != null;
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                return false;
            }
        }
    }
}
