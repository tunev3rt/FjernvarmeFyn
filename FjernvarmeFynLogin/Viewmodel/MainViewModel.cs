using FjernvarmeFynLogin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FjernvarmeFynLogin.Viewmodel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private UserRepository userRepo = new UserRepository();
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<UserViewModel> UsersVM { get; set; }

        public MainViewModel()
        {
            UsersVM = new ObservableCollection<UserViewModel>();
            foreach (User user in userRepo.GetAll())
            {
                UserViewModel uvm = new UserViewModel(user);
                UsersVM.Add(uvm);
            }
        }

        public void AddUser(string name, string department, string email, string password)
        {
            User user = null;
            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(department) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(password))
            {
                user = new User()
                {
                    Name = name,
                    Department = department,
                    Email = email,
                    Password = password
                };
                userRepo.Add(user);
                UserViewModel uvm = new UserViewModel(user);
                UsersVM.Add(uvm);
            }
            else
                throw new Exception("Not all arguments are valid");
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
