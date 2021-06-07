using System;
using System.Collections.Generic;
using System.Text;

namespace TriviaXamarinApp.Models
{
    public class User
    {
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public List<AmericanQuestion> Questions { get; set; }

        public User()
        {

        }

        public User(string email, string nickName, string password)
        {
            this.Email = email;
            this.NickName = nickName;
            this.Password = password;
            this.Questions = new List<AmericanQuestion>();
        }
    }
}
