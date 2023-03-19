using Items.MockData;
using Items.Models;

namespace Items.Services
{
    public class ItemService : IItemService
    {
        private JsonFileItemService JsonFileItemService { get; set; }

        private List<Item> _items { get; set; }
        public ItemService(JsonFileItemService jsonFileItemService)
        {
            JsonFileItemService = jsonFileItemService;
            //_items = MockItems.GetMockItems();
            _items = JsonFileItemService.GetJsonItems().ToList();
        }

        public List<Item> GetAllItems()
        {
            return _items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            JsonFileItemService.SaveJsonItems(_items);
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
        public IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Item> filterList = new List<Item>();
            foreach(Item item in _items)
            {
                if((minPrice == 0 && item.Price <= maxPrice) || (maxPrice == 0 && item.Price >= minPrice) || (item.Price >= minPrice && item.Price <= maxPrice))
                {
                    filterList.Add(item);
                }
            }
            return filterList;
        }

        public void UpdateItem(Item item)
        {
            if (item != null)
            {
                foreach (Item i in _items)
                {
                    if (i.Id == item.Id)
                    {
                        i.Name = item.Name;
                        i.Price = item.Price;
                    }
                }
                JsonFileItemService.SaveJsonItems(_items);
            }
        }

        public Item GetItem(int id)
        {
            foreach(var item in _items)
            {
                if (item.Id == id)
                {
                    return item;
                }      
            }           
            return null;
        }

        public Item DeleteItem(int itemId)
        {
            Item itemToBeDeleted = null;
            foreach (Item item in _items)
            {
                if (item.Id == itemId)
                {
                    itemToBeDeleted = item;
                    break;
                }
            }
            if (itemToBeDeleted != null)
            {
                _items.Remove(itemToBeDeleted);
                JsonFileItemService.SaveJsonItems(_items);
            }
            return itemToBeDeleted;
        }
    }
}
