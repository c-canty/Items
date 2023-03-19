using Items.Models;

namespace Items.Services
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        void AddItem(Item item);
        IEnumerable<Item> NameSearch(string str);
        IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0);
    }
}
