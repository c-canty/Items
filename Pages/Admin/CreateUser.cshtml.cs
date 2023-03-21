using Items.Models;
using Items.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Items.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class CreateUserModel : PageModel
    {
        private UserService _userService { get; set; }

        [BindProperty] public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)] public string Password { get; set; }

        private PasswordHasher<string> _passwordHasher;

        public CreateUserModel(UserService userService)
        {
            _userService = userService;
            _passwordHasher = new PasswordHasher<string>();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.AddUser(new User(UserName, _passwordHasher.HashPassword(null, Password)));
            return RedirectToPage("/Item/GetAllItems");
        }
    }
}
