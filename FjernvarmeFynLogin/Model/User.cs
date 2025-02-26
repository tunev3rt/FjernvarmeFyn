using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernvarmeFynLogin.Model
{
    public class User
    {
        private static int idCount = 1;
        public int UserId { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
        
        public User()
        {
            Name = "Indtast navn";
            Email = "Indtast email";
            Department = "Indtast afdeling";
            Password = "Indtast password";
            UserId = idCount++;
        }
    }
}
