using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instagram.Users;
namespace Instagram.Notifications
{
    //Notification=>id,Text,DateTime,FromUser(bu hansi user terefinden bu bildirishin geldiyidir)
    internal class Notification
    {
        static int id = 1;
        public int Id { get; } = ++id;

        public string DateTime { get; set; }

        public User FromUser { get; set; }

    }
}
