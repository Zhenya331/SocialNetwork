using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Repository.IRepository;
using SocialNetwork.Services.IServices;
using System.Threading.Tasks;

namespace SocialNetwork.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IActionService actionService;
        private readonly IAccountService accountService;

        public ChatHub(IActionService actionService, IAccountService accountService)
        {
            this.actionService = actionService;
            this.accountService = accountService;
        }

        public async Task Send(string user, string message)
        {
            MessageInfo info = new MessageInfo();
            info.EncodeMessage(message);
            long? UserId = await accountService.GetUserID(info.UserName);
            long? FriendID = await accountService.GetUserID(info.FriendName);
            if ((UserId != null) && (FriendID != null))
            {
                await Task.Run(() => actionService.AddMessage((long)UserId, (long)FriendID, info.MessageText));
            }
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

    public class MessageInfo
    {
        public string UserName { get; private set; } = "";
        public string FriendName { get; private set; } = "";
        public string MessageText { get; private set; } = "";

        public void EncodeMessage(string message)
        {
            char border = '_';
            int counter = 1;
            foreach(char msg in message)
            {
                if (border == msg) { counter++; continue; }
                if (counter == 1) { UserName += msg; }
                if (counter == 2) { FriendName += msg; }
                if (counter == 3) { MessageText += msg; }
            }
        }
    }
}
