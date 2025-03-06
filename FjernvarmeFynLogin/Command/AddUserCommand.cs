using FjernvarmeFynLogin.Model;
using FjernvarmeFynLogin.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FjernvarmeFynLogin.Command
{
    public class AddUserCommand : ICommand
    {
        private readonly Action closeWindowAction;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AddUserCommand(Action closeWindowAction)
        {
            this.closeWindowAction = closeWindowAction;
        }

        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if (parameter is UserViewModel uvm)
            {
                if (!string.IsNullOrEmpty(uvm.Name) &&
                    !string.IsNullOrEmpty(uvm.Department) &&
                    !string.IsNullOrEmpty(uvm.Email) &&
                    !string.IsNullOrEmpty(uvm.Password) &&
                    !string.IsNullOrEmpty(uvm.PasswordConfirm))
                    result = true;
            }
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is UserViewModel uvm)
            {
                if (uvm.Password == uvm.PasswordConfirm)
                {
                    User user = new User
                    {
                        Name = uvm.Name,
                        Email = uvm.Email,
                        Department = uvm.Department,
                        Password = uvm.Password
                    };
                    uvm.AddUser(user);
                    MessageBoxResult result = MessageBox.Show("Bruger oprettet i systemet");
                    if (result == MessageBoxResult.OK)
                    {
                        closeWindowAction?.Invoke();
                    }
                }
                else
                    MessageBox.Show("De indtastede passwords matcher ikke. Prøv igen");
            }
        }
    }
}
