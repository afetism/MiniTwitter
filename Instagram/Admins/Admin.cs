using Instagram.Register;
using Instagram.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instagram.Posts;
using Instagram.Notifications;
using System.Globalization;
using System.Reflection.Metadata;
namespace Instagram.Admins
{
    //    Admin=>id,username,email,password,Posts,Notifications

    internal class Admin 
    {
        static int id = 0;

        public Admin(string userName, string email, string password)
        {
            UserName=userName;
            Email=email;
            Password=password;
        }

        public int Id { get; } = ++id;
        public string UserName { get; private set; } =string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get;private set; } = string.Empty;

        public List<Post> Posts { get; private set; } = new();
        
        public List<Notification> Notifications { get; private set; } = new();
        

        public void addPost(string content,String Title)
        {
            if (string.IsNullOrWhiteSpace(content)&&string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Invalid Title or content");
            
                
                Posts.Add(new Post(content,Title));
            
        }

        public void addNotification(User fromUser,string text)
        {
            if (fromUser is null) throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException();
            Notifications.Add(new Notification(fromUser,text));
        }

        public void ShowNotification()
        {
           foreach(var item in Notifications)
                Console.WriteLine(item);

        }

        public void ShowAllAdminPosts()
        {
            foreach(var post in Posts)
            {
                Console.WriteLine($"{post.Id}.{post.Title}                     Published:{post.CreationDateTime}");
                Console.WriteLine(@$"--------------------------Post---------------------------
{post.Content}
                                 LikeCount: {post.LikeCount}   ViewCount: {post.ViewCount}
---------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
        }

        

    }
}
