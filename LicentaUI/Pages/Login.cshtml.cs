using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicentaUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LicentaUI.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginUserModel LoginUserModel { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //face login
            }
            return Page();
        }
    }
}