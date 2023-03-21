using Items.MockData;
using Items.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Items.Pages.Item
{
    public class GetAllItemsModel : PageModel
    {
        public IEnumerable<Models.Item> Items { get; private set; }

        public IItemService _itemService { get; set; }

        [BindProperty] public string SearchString { get; set; }

        [BindProperty] public int MinPrice { get; set; }
        [BindProperty] public int MaxPrice { get; set; }

        public GetAllItemsModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void OnGet()
        {
            Items = _itemService.GetAllItems();
        }
        public void OnGetSortById()
        {
            Items = _itemService.SortById();
        }
		public void OnGetSortByIdDesc()
		{
			Items = _itemService.SortByIdDesc();
		}

		public void OnGetSortByName()
		{
			Items = _itemService.SortByName();
		}
		public void OnGetSortByNameDesc()
		{
			Items = _itemService.SortByNameDesc();
		}
		public void OnGetSortByPrice()
		{
			Items = _itemService.SortByPrice();
		}
		public void OnGetSortByPriceDesc()
		{
			Items = _itemService.SortByPriceDesc();
		}

		public IActionResult OnPostNameSearch()
        {
            Items = _itemService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPostPriceFilter()
        {
            Items = _itemService.PriceFilter(MaxPrice,MinPrice).ToList();
            return Page();
        }
    }
}
