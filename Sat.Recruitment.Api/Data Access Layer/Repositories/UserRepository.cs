using Sat.Recruitment.Api.Data_Access_Layer.Contracts;
using Sat.Recruitment.Api.Data_Access_Layer.Entities;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Api.Data_Access_Layer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        public List<User> ReadUsers()
        {
           var _users = new List<User>();

            var reader = ReadUsersFromFile();

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();

            return _users;
        }
    }
}
