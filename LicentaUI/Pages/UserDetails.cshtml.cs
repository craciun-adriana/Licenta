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
    public class UserDetailsModel : PageModel
    {
        public LicentaApiHttpClient _licentaApiHttpClient;
        public List<PublicUserDetails> User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var cookie = Request.Cookies[".AspNetCore.Identity.Application"] ?? "";
            ///cum aduc id ul userului pe care s-a dat click (dupa ce s-a facut search) in functia mea de mai jos
            ///User = (await _licentaApiHttpClient.GetUserById();
            return Page();
        }
    }
}