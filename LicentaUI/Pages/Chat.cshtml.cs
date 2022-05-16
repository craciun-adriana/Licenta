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
        public List<PublicUserDetails> UserDetails { get; set; }
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
        public void OnPost()
        {
        }
    }
}