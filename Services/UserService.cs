using Items.MockData;
using Items.Models;

namespace Items.Services
{
	public class UserService
	{
		public List<User> Users { get; set; }

		public UserService()
		{
			Users = MockUsers.GetMockUsers();
		}

		public List<User> GetUsers()
		{
			return Users;
		}
	}
}
