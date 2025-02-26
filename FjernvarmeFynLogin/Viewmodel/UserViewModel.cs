using FjernvarmeFynLogin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FjernvarmeFynLogin.Viewmodel
{
    public class UserViewModel
    {
        private UserRepository userRepo = new UserRepository();
        private User user;
        public int UserId { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }

        public UserViewModel()
        {

        } 

        public UserViewModel(User user)
        {
            this.user = user;
            UserId = user.UserId;
            Name = user.Name;
            Email = user.Email;
            Department = user.Department;
            Password = user.Password;
        }

        public void LogIn(string email, string password)
        {
            bool userFound = userRepo.LogIn(email, password);
            if (userFound)
            {
                MessageBox.Show("Login godkendt");
            }
            else if (!userFound)
            {
                MessageBox.Show("Login mislykkedes. Prøv venligst igen");
            }
        }
    }
}
