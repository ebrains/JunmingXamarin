using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace junming
{
    public class User
    {

        public User(string name, string avatar)
        {
            Name = name;
            Avatar = avatar;
        }

        public string Name
        {
            get;
            set;
        }

        public string Avatar
        {
            get;
            set;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
