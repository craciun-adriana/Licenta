using System.Threading.Tasks;
using LicentaUI.HttpClients;
using LicentaUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LicentaUI.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterUserModel RegisterUserModel { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        private LicentaApiHttpClient _licentaApiHttpClient;

        public RegisterModel(LicentaApiHttpClient licentaApiHttpClient)
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
                var isRegister = await _licentaApiHttpClient.RegisterUserAsync(RegisterUserModel);
                if (!isRegister)
                {
                    ErrorMessage = "Could not register.";
                    return Page();
                }
                ErrorMessage = "register";
                return Redirect("/Index");
            }
            return Page();
        }
    }
}