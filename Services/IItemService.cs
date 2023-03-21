using Items.Models;

namespace Items.Services
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        void AddItem(Item item);
        IEnumerable<Item> NameSearch(string str);
        IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0);
        void UpdateItem(Item item);
        Item GetItem(int id);
        Item DeleteItem(int id);
        IEnumerable<Item> SortById();
		IEnumerable<Item> SortByIdDesc();
		IEnumerable<Item> SortByName();
		IEnumerable<Item> SortByNameDesc();
		IEnumerable<Item> SortByPrice();
		IEnumerable<Item> SortByPriceDesc();

	}
}
