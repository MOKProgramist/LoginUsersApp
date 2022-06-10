using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace LoginApp
{
    internal class User
    {

        //List<User> list = new List<User>();

        public string Login { get; set; }   
        public string Password { get; set; }

        static public User FindUserOrLogin(string login, string pass)
        {
            var user = new User()
            {
                Login = login,
                Password = pass
            };

            ListUser test = new ListUser();
            User findUser = (User)test.FindUser(user);
            Console.WriteLine(findUser);

            if(findUser != null)
            {
                if (findUser.Password == pass) return findUser;
                else throw new ArgumentException("Пользователь не найден 1");
            } else throw new ArgumentException("Пользователь не найден");
        }
        // создания пользователя
        public User CreateUser(string login, string pass)
        {
            var user = new User()
            {
                Login = login,
                Password = pass
            };

            ListUser test = new ListUser();
            test.Add(user);
            test.Show();
            return user;
        }
        // список пользователей в системе
        public void GetUsers()
        {
            ListUser test = new ListUser();
            test.Show();
        }
    }
}
