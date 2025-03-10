using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_ECOMMERCE
{
    public abstract class User
    {
        private string _username;
        private string _password;
        private string _email;

        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    System.Console.WriteLine("Username cannot be empty");
                }
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return "**********";
            }
            set
            {

                _password = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {

                _email = value;
            }
        }

        public void Login()
        {
            System.Console.WriteLine("write the username");
            _username = Console.ReadLine();
            System.Console.WriteLine("write the password");
            _password = Console.ReadLine();
            System.Console.WriteLine("Login is done successfully");
        }


    }
}