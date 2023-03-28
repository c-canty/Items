using Items.Models;

namespace Items.Services
{
    public class OrderService
    {
        public List<Order> Orders { get; set; }
        
        private DBService<Order> _dbService;

        public OrderService(DBService<Order> dBService)
        {
            _dbService = dBService;           
            Orders = _dbService.GetObjects().Result;
            //Users = MockUsers.GetMockUsers().ToList();

        }

        public List<Order> GetOrders()
        {
            return Orders;

        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
            _dbService.AddObject(order);
            _dbService.SaveObject(Orders);
        }
    }
}
