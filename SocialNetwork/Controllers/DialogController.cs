using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.IServices;
using SocialNetwork.ViewModels;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class DialogController : Controller
    {
        private readonly IAccountService accountService;

        public DialogController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<IActionResult> Chat(string FriendName)
        {
            long? FriendID = await accountService.GetUserID(FriendName);
            long? UserID = await accountService.GetUserID(User.Identity.Name);

            if ((FriendID != null) && (UserID != null))
            {
                ChatModel chat = new ChatModel
                {
                    user = await accountService.GetUserProfile((long)UserID),
                    friend = await accountService.GetUserProfile((long)FriendID),
                    messages = await accountService.GetMessagesList((long)UserID, (long)FriendID)
                };
                return View(chat);
            }
            return StatusCode(404);
        }
    }
}
