using Items.Models;

namespace Items.MockData
{
    public class MockItems
    {
        private static List<Item> items = new List<Item>() {
            new Item(1, "PC", 5999),
            new Item(2, "Skærm", 1999),
            new Item(3, "Tastatur", 999)
        };

        public static List<Item> GetMockItems()
        {
            return items;
        }
    }
}
