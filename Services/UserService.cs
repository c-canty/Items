using Items.Migrations;
using Items.MockData;
using Items.Models;

namespace Items.Services
{
	public class UserService
	{
		public List<User> Users { get; set; }
		private JsonFileService<User> _jsonFileService;
		private DBService<User> _dbService;

		public UserService(DBService<User> dBService, JsonFileService<User> jsonFileService)
		{
			_dbService = dBService;
			_jsonFileService = jsonFileService;
			Users = _dbService.GetObjects().Result;
			//Users = MockUsers.GetMockUsers().ToList();

		}

		public List<User> GetUsers()
        {
			return Users;
            
        }

        public void AddUser(User user)
        {
            Users.Add(user);
            _dbService.AddObject(user);
            _dbService.SaveObject(Users);
        }

        public User GetUserByUserName(string userName)
		{
			User user = Users.Find(_user => _user.UserName == userName);
			return user;
		}
    }
}
