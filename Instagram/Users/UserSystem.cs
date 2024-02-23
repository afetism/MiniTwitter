using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Users
{
    internal class UserSystem
    {
        List<User> AvailableAccess { get;  } = new();

        public User SignIn(string email, string password)
        {

            foreach (var user in AvailableAccess)
            {
                if (user.Email == email && user.Password==password)
                    return user;

            }
            return null;

        }

        public User SignUp(string email, string password, string surname, string name, int age)
        {

            foreach (var user in AvailableAccess)
            {
                if (user.Email == email)
                    return null;

            }
            var newUser = new User (name,surname,age,email,password);
            AvailableAccess.Add(newUser);
            return newUser;

        }
    }
}
