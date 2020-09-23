using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.IServices;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class RequestsFriendController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IActionService actionService;

        public RequestsFriendController(IAccountService accountService, IActionService actionService)
        {
            this.accountService = accountService;
            this.actionService = actionService;
        }

        public async Task<IActionResult> IncomingRequests()
        {
            long? id = await accountService.GetUserID(User.Identity.Name);

            if (id != null)
            {
                List<User> model = await accountService.GetFriendRequestsIncomingList((long)id);
                return View(model);
            }
            return StatusCode(500);
        }

        public async Task<IActionResult> OutgoingRequests()
        {
            long? id = await accountService.GetUserID(User.Identity.Name);

            if (id != null)
            {
                List<User> model = await accountService.GetFriendRequestsOutgoingList((long)id);
                return View(model);
            }
            return StatusCode(500);
        }

        [HttpPost]
        public async Task<IActionResult> SendRequestFriend(string RequestFriendName)
        {
            long? UserID = await accountService.GetUserID(User.Identity.Name);
            long? PotentialFriendID = await accountService.GetUserID(RequestFriendName);

            if ((UserID != null) && (PotentialFriendID != null))
            {
                await Task.Run(() => actionService.SendRequestFriend((long)UserID, (long)PotentialFriendID));
                return RedirectToAction("FindUsers", "Home");
            }
            return StatusCode(500);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFriend(string FriendName)
        {
            long? UserID = await accountService.GetUserID(User.Identity.Name);
            long? FriendID = await accountService.GetUserID(FriendName);

            if ((UserID != null) && (FriendID != null))
            {
                await Task.Run(() => actionService.DeleteFriend((long)UserID, (long)FriendID));
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptRequestFriend(string PotentialFriendName)
        {
            long? UserID = await accountService.GetUserID(User.Identity.Name);
            long? PotentialFriendID = await accountService.GetUserID(PotentialFriendName);

            if ((UserID != null) && (PotentialFriendID != null))
            {
                await Task.Run(() => actionService.AcceptRequestFriend((long)UserID, (long)PotentialFriendID));
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequestFriend(string PotentialFriendName)
        {
            long? UserID = await accountService.GetUserID(User.Identity.Name);
            long? PotentialFriendID = await accountService.GetUserID(PotentialFriendName);

            if ((UserID != null) && (PotentialFriendID != null))
            {
                await Task.Run(() => actionService.DeleteRequestFriend((long)UserID, (long)PotentialFriendID));
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);
        }

        [HttpPost]
        public async Task<IActionResult> CancelRequestFriend(string PotentialFriendName)
        {
            long? UserID = await accountService.GetUserID(User.Identity.Name);
            long? PotentialFriendID = await accountService.GetUserID(PotentialFriendName);

            if ((UserID != null) && (PotentialFriendID != null))
            {
                await Task.Run(() => actionService.CancelRequestFriend((long)UserID, (long)PotentialFriendID));
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);
        }
    }
}