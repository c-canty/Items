using Items.DAO;
using Items.Models;
using Items.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Items.Pages.Order
{
    public class MyOrdersModel : PageModel
    {
        public UserService UserService { get; set; }
        public IEnumerable<OrderDAO> MyOrders { get; set; }
          

        public MyOrdersModel(UserService userService) 
        {
            UserService = userService;

        }

        public void OnGet()
        {
			User CurrentUser = UserService.GetUserByUserName(HttpContext.User.Identity.Name);
			MyOrders = UserService.GetUserOrders(CurrentUser);
            
		}
    }
}
