using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;
using SocialNetwork.Repository.IRepository;
using System;

namespace SocialNetwork.Repository.RepositoryImplementation
{
    public class AccountActions : IAccountActions
    {
        protected readonly Social_networkContext context;

        public AccountActions(Social_networkContext context)
        {
            this.context = context;
        }

        public async void AcceptRequestFriend(long UserID, long RequestFriendID)
        {
            try
            {
                RequestFriend requestFriend = await context.RequestFriend
                                                           .FirstOrDefaultAsync(p => p.SendUserId == RequestFriendID && p.RecieveUserId == UserID);
                if (requestFriend != null)
                {
                    context.Friend.Add(new Friend { UserId = RequestFriendID, FriendId = UserID, AddFriendDate = DateTime.Today });
                    context.RequestFriend.Remove(requestFriend);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }
        }

        public async void AddMessage(long UserID, long FriendID, string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message) == false)
                {
                    context.Message.Add(new Message { SendId = UserID, RecieveId = FriendID, MessageText = message, SendDate = DateTime.Now });
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = ex.ToString();
            }
        }

        public async void CancelRequestFriend(long UserID, long RequestFriendID)
        {
            try
            {
                RequestFriend requestFriend = await context.RequestFriend
                                                           .FirstOrDefaultAsync(p => p.SendUserId == UserID && p.RecieveUserId == RequestFriendID);
                if (requestFriend != null)
                {
                    context.RequestFriend.Remove(requestFriend);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }
        }

        public async void DeleteFriend(long UserID, long FriendID)
        {
            try
            {
                Friend friend = await context.Friend
                                             .FirstOrDefaultAsync(p => (p.UserId == UserID && p.FriendId == FriendID)
                                                                    || (p.UserId == FriendID && p.FriendId == UserID));
                if (friend != null)
                {
                    context.Friend.Remove(friend);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }
        }

        public async void DeleteRequestFriend(long UserID, long RequestFriendID)
        {
            try
            {
                RequestFriend requestFriend = await context.RequestFriend
                                                           .FirstOrDefaultAsync(p => p.SendUserId == RequestFriendID && p.RecieveUserId == UserID);
                if (requestFriend != null)
                {
                    context.RequestFriend.Remove(requestFriend);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }
        }

        public async void SendRequestFriend(long UserID, long RequestFriendID)
        {
            try
            {
                RequestFriend requestFriend = await context.RequestFriend
                                                           .FirstOrDefaultAsync(p => (p.SendUserId == UserID && p.RecieveUserId == RequestFriendID)
                                                                                  || (p.SendUserId == RequestFriendID && p.RecieveUserId == UserID));
                if (requestFriend == null)
                {
                    context.RequestFriend.Add(new RequestFriend { SendUserId = UserID, RecieveUserId = RequestFriendID, DateSend = DateTime.Today });
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }
        }
    }
}
