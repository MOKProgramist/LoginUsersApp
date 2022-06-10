using LoginApp;
using System;
using System.Collections.Generic;

namespace LoginApp
{
    internal class ListUser
   
    {
        List<User> list = new List<User>();

        public object FindUser(User user)
        {

            return list.Find(delegate (User user_)
            {
                return user_.Login == user.Login;
            }
            );
        }
        public void Add(User user)
        {
            list.Add(user);
        }

        public void Show()
        {
            foreach (var user in list)
            {
                Console.WriteLine(user.Login + " " + user.Password);
            }
        }
    }
}
