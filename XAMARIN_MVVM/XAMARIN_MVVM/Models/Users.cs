using System;
using System.Collections.Generic;
using System.Text;

namespace XAMARIN_MVVM.Models
{
    public static class Users
    {
        public static List<User> users = new List<User>();
      
        public static List<User> GetUsers()
        {
            users.Add(new User("Jonas", "123456"));
            users.Add(new User("Petras", "123456"));
            users.Add(new User("Juozas", "123456"));
            users.Add(new User("Ailandas", "123456"));
            return users;


        }
    }
}
