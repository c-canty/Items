﻿using Items.MockData;
using Items.Models;

namespace Items.Services
{
	public class UserService
	{
		public List<User> Users { get; set; }
		private JsonFileService<User> _jsonFileService;

		public UserService(JsonFileService<User> jsonFileService)
		{
			_jsonFileService = jsonFileService;
            Users = _jsonFileService.GetJsonObjects().ToList();
        }

		public List<User> GetUsers()
		{
			return Users;
		}
	}
}
