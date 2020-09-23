using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;
using SocialNetwork.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.RepositoryImplementation
{
    public class AccountInformation : IAccountInformation
    {
        protected readonly Social_networkContext context;

        public AccountInformation(Social_networkContext context)
        {
            this.context = context;
        }
        public async Task<List<User>> GetFriendRequestsIncomingList(long UserID)
        {
            try
            {
                var friendRequests = await context.RequestFriend.Where(p => p.RecieveUserId == UserID)
                                            .OrderBy(p => p.DateSend).ToListAsync();
                List<User> result = new List<User>();
                foreach (var friendRequest in friendRequests)
                {
                    result.Add(await context.User.FirstOrDefaultAsync(p => p.Id == friendRequest.SendUserId));
                }
                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<List<User>> GetFriendRequestsOutgoingList(long UserID)
        {
            try
            {
                var friendRequests = await context.RequestFriend.Where(p => p.SendUserId == UserID)
                                            .OrderBy(p => p.DateSend).ToListAsync();
                List<User> result = new List<User>();
                foreach (var friendRequest in friendRequests)
                {
                    result.Add(await context.User.FirstOrDefaultAsync(p => p.Id == friendRequest.RecieveUserId));
                }
                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<List<User>> GetFriendsList(long UserID)
        {
            try
            {
                var friends = await context.Friend.Where(p => p.UserId == UserID || p.FriendId == UserID)
                                            .OrderBy(p => p.AddFriendDate).ToListAsync();
                List<User> result = new List<User>();
                foreach(var friend in friends)
                {
                    if (friend.UserId == UserID)
                    {
                        result.Add(await context.User.FirstOrDefaultAsync(p => p.Id == friend.FriendId));
                    }

                    if (friend.FriendId == UserID)
                    {
                        result.Add(await context.User.FirstOrDefaultAsync(p => p.Id == friend.UserId));
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<List<Message>> GetMessagesList(long UserID, long FriendID)
        {
            try
            {
                var messages = await context.Message.Where(p => (p.SendId == UserID && p.RecieveId == FriendID) 
                                                             || (p.SendId == FriendID && p.RecieveId == UserID)).ToListAsync();
                return messages;
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<long?> GetUserID(string UserName)
        {
            try
            {
                User user = await context.User.FirstOrDefaultAsync(p => p.UserName == UserName);
                long? result = null;
                if (user != null)
                {
                    result = user.Id;
                }
                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<User> GetUserProfile(long UserID)
        {
            try
            {
                var user = await context.User.FirstOrDefaultAsync(p => p.Id == UserID);
                return user;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<List<User>> GetUsersList(string UserName)
        {
            try
            {
                var result = await context.User.Where(p => p.UserName.Contains(UserName)).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
    }
}
