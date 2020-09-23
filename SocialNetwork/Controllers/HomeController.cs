using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.IServices;
using SocialNetwork.ViewModels;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAccountService accountService;
        private readonly ICheckService checkService;

        public HomeController(IAccountService accountService, ICheckService checkService)
        {
            this.accountService = accountService;
            this.checkService = checkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Profile(string UserName)
        {
            long? id = await accountService.GetUserID(UserName);

            if (id != null)
            {
                User model = await accountService.GetUserProfile((long)id);
                if (model != null)
                {
                    return View(model);
                }
            }
            return StatusCode(404);
        }

        [HttpGet]
        public async Task<IActionResult> Friends(string UserName)
        {
            long? id = await accountService.GetUserID(UserName);

            if (id != null)
            {
                User user = await accountService.GetUserProfile((long)id);
                List<User> friends = await accountService.GetFriendsList((long)id);
                FriendsListModel model = new FriendsListModel(user, friends);
                return View(model);
            }
            return StatusCode(500);
        }

        public async Task<IActionResult> Messages()
        {
            long? id = await accountService.GetUserID(User.Identity.Name);

            if (id != null)
            {
                List<User> model = await accountService.GetFriendsList((long)id);
                return View(model);
            }
            return StatusCode(500);
        }

        public IActionResult FriendRequests()
        {
            return RedirectToAction("IncomingRequests", "RequestsFriend");
        }

        [HttpGet]
        public IActionResult FindUsers()
        {
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> FindUsers(string Search)
        {
            List<User> users = await accountService.GetUsersList(Search);
            List<FindUserModel> model = new List<FindUserModel>();

            foreach (User user in users)
            {
                long? UserID = await accountService.GetUserID(User.Identity.Name);
                long? FindUserID = await accountService.GetUserID(user.UserName);
                bool CheckFriend = await checkService.IsMyFriend((long)UserID, (long)FindUserID);
                bool CheckRequestFriend = await checkService.IsMyRequestFriend((long)UserID, (long)FindUserID);
                bool CheckResult = true;
                if ((CheckFriend == false) && (CheckRequestFriend == false))
                {
                    CheckResult = false;
                }
                model.Add(new FindUserModel { user = user, IsMyFriend = CheckResult });
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
