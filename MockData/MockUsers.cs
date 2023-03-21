using Items.Models;
using Microsoft.AspNetCore.Identity;

namespace Items.MockData
{
	public class MockUsers
	{
		public static PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
		public static List<User> Users = new List<User>()
        {
			new User("Christian", passwordHasher.HashPassword(null, "1234")),
			new User("Mads", passwordHasher.HashPassword(null, "5678")),
			new User("Mille", passwordHasher.HashPassword(null, "2468")),
            new User("admin", passwordHasher.HashPassword(null, "secret"))
        };

		public static List<User> GetMockUsers()
		{
			return Users;
		}
			

	}
}
