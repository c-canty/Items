using Items.DAO;
using Items.EFDbContext;
using Items.Models;

namespace Items.Services
{
	public class UserDBService : DBService<User>
	{
		
		public List<OrderDAO> GetOrdersByUserIdAsync(int id)
		{
			List<OrderDAO> orderList = new List<OrderDAO>();
		    using (var context = new ItemDbContext())
			{
				var orders = from order in context.Orders
							 join item in context.Items on order.ItemId equals item.Id
							 join user in context.Users on order.UserId equals user.Id
							 where user.Id == id
							 select new OrderDAO()
							 {
								 OrderId = order.OrderId,
								 Date = order.dateTime,
								 UserId = user.Id,
								 UserName = user.UserName,
								 ItemId = item.Id,
								 ItemName = item.Name,
								 Price = item.Price,
								 Count = order.Count,
								 //TotalPrice = item.Price * order.Count, 

							 };
				orderList = orders.ToList();
			}
			return orderList;	
		}
	}
}
