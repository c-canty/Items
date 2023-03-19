using Items.MockData;
using Items.Models;

namespace Items.Services
{
    public class ItemService : IItemService
    {

        private List<Item> _items = MockItems.GetMockItems();

        public List<Item> GetAllItems()
        {
            return _items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
        public IEnumerable<Item> NameSearch(string str)
        {
            List<Item> nameSearch = new List<Item>();
            foreach (Item item in _items)
            {
                if (item.Name.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(item);
                }
            }

            return nameSearch;
        }
    }
}
