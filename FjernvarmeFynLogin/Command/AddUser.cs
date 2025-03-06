using FjernvarmeFynLogin.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FjernvarmeFynLogin.Command
{
    public class AddUser : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            bool result = false;
            if (parameter is UserViewModel uvm)
            {

            }
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is UserViewModel uvm)
            {
                uvm.Add
            }
        }
    }
}
