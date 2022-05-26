using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicentaUI.HttpClients;
using LicentaUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LicentaUI.Pages
{
    public class ChatModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        public List<PublicUserDetails> UserDetails { get; set; } = new();
        public List<PublicUserDetails> UsersFind { get; set; } = new();
        public List<MessageModel> Messages { get; set; }
        public string ErrorMessage { get; set; }

        private LicentaApiHttpClient _licentaApiHttpClient;

        public ChatModel(LicentaApiHttpClient licentaApiHttpClient)
        {
            _licentaApiHttpClient = licentaApiHttpClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var cookie = Request.Cookies[".AspNetCore.Identity.Application"] ?? "";
            var otherId = "";
            UserDetails = (await _licentaApiHttpClient.GetLastConversationsForUser(cookie)).ToList();
            ///cum trimit id ul pers pe care am dat click in app
            // Messages = (await _licentaApiHttpClient.GetAllMessagesBetweenUsers(otherId, cookie)).ToList();
            Messages = new List<MessageModel>();

            return Page();
        }

        /// <summary>
        /// cand apas send
        /// </summary>
        public async Task<IActionResult> OnPost()
        {
            Messages = new List<MessageModel>();
            var cookie = Request.Cookies[".AspNetCore.Identity.Application"] ?? "";

            UserDetails = (await _licentaApiHttpClient.GetLastConversationsForUser(cookie)).ToList();
            UsersFind = (await _licentaApiHttpClient.FindUsersByUsername(UserName, cookie)).ToList();

            return Page();
        }

        public async Task<IEnumerable<MessageModel>> GetUserById(string id)
        {
            return await _licentaApiHttpClient.GetAllMessagesBetweenUsers(id, "");
        }
    }
}