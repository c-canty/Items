using Items.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Items.Pages.Item
{
    public class EditItemModel : PageModel
    {
        public IItemService _itemService { get; set; }
        [BindProperty] public Models.Item Item { get; set; }

        public EditItemModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult OnGet(int id)
        {
            Item = _itemService.GetItem(id);
            if(Item == null)
            {
                return RedirectToPage("/NotFound");       
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _itemService.UpdateItem(Item);
            return RedirectToPage("GetAllItems");
        }
    }
}
