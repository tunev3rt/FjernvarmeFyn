using FjernvarmeFynLogin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            User user = userRepo.Add(name, department, email, password);
            UserViewModel uvm = new UserViewModel(user);
            UsersVM.Add(uvm);
        }
    }
}
