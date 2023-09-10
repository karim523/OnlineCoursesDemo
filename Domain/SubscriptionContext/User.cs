using SimpleObjects.SharedContext;
using System;

namespace SimpleObjects.SubscriptionContext
{
    public class User : Base
    {
        public User(string username, string password)
        {
            
            SetName(username);
            SetPassword(password);
        }

        public string Username { get;private set; }
        public string Password { get;private set; }

        private void SetName(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("Invalid Username");

            if (!(username.Length >= 3 && username.Length <= 150)) throw new ArgumentException("Invalid Username");
            Username = username;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("Invalid Password");
            if (!(password.Length >= 3 && password.Length <= 150)) throw new ArgumentException("Invalid Password");

            Password = password;
        }
    }
}