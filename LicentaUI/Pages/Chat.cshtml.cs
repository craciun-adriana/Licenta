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
        public string ErrorMessage { get; set; }

        private LicentaApiHttpClient _licentaApiHttpClient;

        public ChatModel(LicentaApiHttpClient licentaApiHttpClient)
        {
            _licentaApiHttpClient = licentaApiHttpClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var cookie = Request.Cookies[".AspNetCore.Identity.Application"] ?? "";

            UserDetails = (await _licentaApiHttpClient.GetLastConversationsForUser(cookie)).ToList();

            return Page();
        }

        /// <summary>
        /// cand apas send
        /// </summary>
        public async Task<IActionResult> OnPost()
        {
            var cookie = Request.Cookies[".AspNetCore.Identity.Application"] ?? "";

            UserDetails = (await _licentaApiHttpClient.GetLastConversationsForUser(cookie)).ToList();
            UsersFind = (await _licentaApiHttpClient.FindUsersByUsername(UserName, cookie)).ToList();

            return Page();
        }
    }
}