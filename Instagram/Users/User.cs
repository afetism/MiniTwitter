using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instagram.Register;
namespace Instagram.Users
{
    internal class User
    {
        //User => id,name,surname,age,email,password
        static int id = 0;

        public User(string name, string surname, int age, string email, string password)
        {
            Name=name;
            Surname=surname;
            Age=age;
            Email=email;
            Password=password;
        }

        public int Id { get; } = ++id;
        public string  Name { get; private set; }
        public string Surname { get; private  set; }
        public int Age {get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

       
    }
}
