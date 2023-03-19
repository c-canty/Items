using Items.MockData;
using Items.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Items.Pages.Item
{
    public class GetAllItemsModel : PageModel
    {
        public List<Models.Item> Items { get; private set; }

        public IItemService _itemService { get; set; }

        [BindProperty] public string SearchString { get; set; }
        
        public GetAllItemsModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void OnGet()
        {
            Items = _itemService.GetAllItems();
        }

        public IActionResult OnPostNameSearch()
        {
            Items = _itemService.NameSearch(SearchString).ToList();
            return Page();
        }
    }
}
