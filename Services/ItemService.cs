using Items.MockData;
using Items.Models;

namespace Items.Services
{
    public class ItemService : IItemService
    {
        private JsonFileService<Item> _jsonFileService { get; set; }
        private DBService<Item> _dbService { get; set; }

        private List<Item> _items { get; set; }
        public ItemService(JsonFileService<Item> jsonFileService, DBService<Item> dBService)
        {
            _jsonFileService = jsonFileService;
            _dbService = dBService;
            //_items = MockItems.GetMockItems();
            //_items = _jsonFileService.GetJsonObjects().ToList();
            _items = _dbService.GetObjects().Result;
        }

        public List<Item> GetAllItems()
        {
            return _items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            _dbService.AddObject(item);
            _dbService.SaveObject(_items);
        }

        public IEnumerable<Item> NameSearch(string str)
        {
            List<Item> nameSearch = new List<Item>();
            if(str != null) 
            {
                Item item = _items.Find(i => i.Name.ToLower().Contains(str.ToLower()));
                if (item != null)
                {
                    nameSearch.Add(item);
                }
                return nameSearch;
            }
            else
            {
                return _items;
            }
            //foreach (Item item in _items)
            //{
            //    if (item.Name.ToLower().Contains(str.ToLower()))
            //    {
            //        nameSearch.Add(item);
            //    }
            //}
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
                _dbService.UpdateObject(item);
                _dbService.SaveObject(_items);
            }
        }

        public Item GetItem(int id)
        {

            Models.Item item = _items.Find(i => i.Id.Equals(id));
            if(item != null)    
            return item;
            //foreach(var item in _items)
            //{
            //    if (item.Id == id)
            //    {
            //        return item;
            //    }      
            //}           
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
                _dbService.DeleteObject(itemToBeDeleted);
                _dbService.SaveObject(_items);
            }
            return itemToBeDeleted;
        }

        public IEnumerable<Item> SortById()
        {
            //_items.Sort();
            //return _items;

            IEnumerable<Item> list = from item in _items
                       orderby item.Id ascending
                       select item;
            return list;
                       
        }

		public IEnumerable<Item> SortByIdDesc()
		{
			IEnumerable<Item> list = from item in _items
									 orderby item.Id descending
									 select item;
			return list;
		}

		public IEnumerable<Item> SortByName()
		{
			IEnumerable<Item> list = from item in _items
									 orderby item.Name ascending
									 select item;
			return list;
		}

		public IEnumerable<Item> SortByNameDesc()
		{
			IEnumerable<Item> list = from item in _items
									 orderby item.Name descending
									 select item;
			return list;
		}

		public IEnumerable<Item> SortByPrice()
		{
			IEnumerable<Item> list = from item in _items
									 orderby item.Price ascending
									 select item;
			return list;
		}

		public IEnumerable<Item> SortByPriceDesc()
		{
			IEnumerable<Item> list = from item in _items
									 orderby item.Price descending
									 select item;
			return list;
		}
	}
}
