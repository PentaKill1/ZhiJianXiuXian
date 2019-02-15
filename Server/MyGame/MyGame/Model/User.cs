using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Model
{
    class User
    {
        public User(string nickname, string username, string password)
        {
            this.nickname = nickname;
            this.Username = username;
            this.Password = password;
        }
        public string nickname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
