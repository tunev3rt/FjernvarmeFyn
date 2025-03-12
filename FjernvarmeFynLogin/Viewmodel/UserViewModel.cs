using FjernvarmeFynLogin.Authentication;
using FjernvarmeFynLogin.Command;
using FjernvarmeFynLogin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
        public string PasswordConfirm { get; set; }

        public ICommand AddUserCommand { get; set; }

        public ICommand LogInCommand { get; set; }

        public Action CloseWindowAction { get; set; }

        public UserViewModel()
        {
            AddUserCommand = new AddUserCommand(() => CloseWindowAction?.Invoke());
            LogInCommand = new LogInCommand(() => CloseWindowAction?.Invoke());
        }

        public void AddUser(User user)
        {
            userRepo.Add(user);
        }
    }
}