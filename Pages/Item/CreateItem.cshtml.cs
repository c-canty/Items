using Items.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Items.Pages.Item
{
    public class CreateItemModel : PageModel
    {
        public IItemService _itemService { get; set; }
        [BindProperty] public Models.Item Item { get; set; }

        public CreateItemModel(IItemService itemService)
        {
            _itemService = itemService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _itemService.AddItem(Item);
            return RedirectToPage("GetAllItems");
        }
    }
}
