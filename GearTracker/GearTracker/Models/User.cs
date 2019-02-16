using System;
using System.Collections.Generic;
using System.Text;

namespace GearTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User()
        {

        }
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
