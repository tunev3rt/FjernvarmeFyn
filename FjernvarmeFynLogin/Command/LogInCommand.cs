using FjernvarmeFynLogin.Authentication;
using FjernvarmeFynLogin.View;
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
    public class LogInCommand : ICommand
    {
        private readonly Action closeWindowAction;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public LogInCommand(Action closeWindowAction)
        {
            this.closeWindowAction = closeWindowAction;
        }

        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if (parameter is UserViewModel uvm)
            {
                if (!string.IsNullOrEmpty(uvm.Email) && !string.IsNullOrEmpty(uvm.Password))
                {
                    result = true;
                }
            }
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is UserViewModel uvm)
            {
                bool adminFound = LogInHandler.LogIn(uvm.Email, uvm.Password);
                if (adminFound)
                {
                    AdminMainWindow amw = new AdminMainWindow();
                    closeWindowAction?.Invoke();
                    amw.ShowDialog();
                }
                else if (!adminFound)
                {
                    bool userFound = LogInHandler.LogIn2(uvm.Email, uvm.Password);
                    if (userFound)
                    {
                        CreateTicketWindow ctw = new CreateTicketWindow(uvm.Email);
                        closeWindowAction?.Invoke();
                        ctw.ShowDialog();
                    }
                    else if (!userFound)
                    {
                        MessageBox.Show("Login mislykkedes. Prøv venligst igen");
                    }
                }
            }
        }
    }
}
