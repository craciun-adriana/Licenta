using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicentaUI.HttpClients;
using LicentaUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LicentaUI.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginUserModel LoginUserModel { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        private LicentaApiHttpClient _licentaApiHttpClient;

        public LoginModel(LicentaApiHttpClient licentaApiHttpClient)
        {
            _licentaApiHttpClient = licentaApiHttpClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var cookies = await _licentaApiHttpClient.LoginUserAsync(LoginUserModel);
                if (!cookies.Any())
                {
                    ErrorMessage = "Could not login.";
                    return Page();
                }
                Response.Cookies.Append(cookies.First().Split("=")[0], cookies.First().Split("=")[1]);
                ErrorMessage = "";
                return Redirect("/Home");
            }
            return Page();
        }
    }
}