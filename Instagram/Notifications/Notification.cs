using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instagram.Users;
namespace Instagram.Notifications
{
    //Notification=>id,Text,DateTime,FromUser(bu hansi user terefinden bu bildirishin geldiyidir)
    internal class Notification
    {
        static int id = 0;

        public Notification(User fromUser,string text)
        {
            Time =DateTime.Now.ToString("dd.MM.YYYY");
            Text= text;
            FromUser =fromUser;
        }

        public int Id { get; } = ++id;

        public string Text { get; }
        public string Time { get; set; }

        public User FromUser { get; set; }


        public override string ToString()
        {
            return $" Id: {Id} Message: {Text} From User: {FromUser.Name+" "+ FromUser.Surname}";
        }





    }
}
