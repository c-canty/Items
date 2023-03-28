using Items.Models;
using Items.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Items.Pages.Order
{
    public class OrderItemModel : PageModel
    {
        public IItemService itemService { get; set; }
        public UserService userService { get; set; }
        public OrderService orderService { get; set; }
        public User User { get; set; }
        public Models.Order Order { get; set; } = new Models.Order();
		public Models.Item Item { get; set; }
        
        [BindProperty] public int Count { get; set; }

        public OrderItemModel(IItemService _itemService, UserService _userService, OrderService _orderService)
        {
            itemService = _itemService;
            userService = _userService;
            orderService = _orderService;
            
        }

        public void OnGet(int id)
        {
            Item = itemService.GetItem(id);
            User = userService.GetUserByUserName(HttpContext.User.Identity.Name);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Item = itemService.GetItem(id);
            User = userService.GetUserByUserName(HttpContext.User.Identity.Name);
            Order.UserId = User.Id;
            Order.ItemId = Item.Id;
            Order.dateTime = DateTime.Now;
            Order.Count = Count;
            orderService.AddOrder(Order);
            return RedirectToPage("../Item/GetAllItems");
        }
    }
}
