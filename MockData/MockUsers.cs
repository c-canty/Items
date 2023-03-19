using Items.Models;

namespace Items.MockData
{
	public class MockUsers
	{
		public static List<User> Users = new List<User>()
		{
			new User("Christian","1234"),
			new User("Mads","5678"),
			new User("Mille","2468")
		};

		public static List<User> GetMockUsers()
		{
			return Users;
		}
			

	}
}
