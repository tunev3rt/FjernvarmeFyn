using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FjernvarmeFynLogin.Model
{
    public class UserRepository
    {
        private List<User> users = new List<User>();

        public User Add(string name, string department, string email, string password)
        {
            User result = null;

            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(department) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(password)
                )
            {
                result = new User()
                {
                    Name = name,
                    Department = department,
                    Email = email,
                    Password = password,
                };
                users.Add(result);
                using (StreamWriter sw = new StreamWriter("Users.txt", true))
                {
                    sw.WriteLine($"{email};{password}");
                }
            }
            else
                throw new Exception("Not all arguments are valid");

            return result;
        }

        public bool LogIn(string email, string password)
        {
            bool userFound = false;
            using (StreamReader sr = new StreamReader("Users.txt"))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split(";");
                    if (parts[0] == email && parts[1] == password)
                    {
                        userFound = true;
                    }
                    line = sr.ReadLine();
                }
            }
            return userFound;
        }

        public List<User> GetAll() 
        {
            return users;
        }
    }
}
