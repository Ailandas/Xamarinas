using System;
using System.Collections.Generic;
using System.Text;

namespace XAMARIN_MVVM.Models
{
    public class User
    {
        private string username;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public User(string usn, string psw)
        {
            username = usn;
            password = psw;
        }
    }
}
