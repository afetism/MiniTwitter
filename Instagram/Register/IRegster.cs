using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Register
{
    internal interface IRegister<T>
    {
        static  List<T> AvailableAccess { get; }

        bool SignIn(string email, string password);

        bool SignUp(string email, string password, string surname, string name, int age);

    }
    internal interface IUserRegister<Admin> : IRegister<Admin>
    { 

    }



}
