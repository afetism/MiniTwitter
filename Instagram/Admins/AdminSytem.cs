using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instagram.Users;
namespace Instagram.Admins
{
    internal class AdminSytem
    {
       public List<Admin> admin { get; } = new List<Admin>();
        public Dictionary<int, bool> LikedPosts { get; } = new Dictionary<int, bool>();


        public Admin SignIn(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email)&&string.IsNullOrWhiteSpace(password))
                throw new Exception("Invalid data");

            foreach (var user in admin)
            {
                if (user.Email == email && user.Password==password)
                    return user;

            }
            return null;
        }

        public Admin SignUp(string email, string password, string userName)
        {
            if (string.IsNullOrWhiteSpace(email)&&string.IsNullOrWhiteSpace(password) && string.IsNullOrWhiteSpace(userName))
                throw new Exception("Invalid data");
            foreach (var user in admin)
            {
                   if (user.Email == email || user.UserName==userName)
                   return null;
                

            }
            var newUser = new Admin(userName,email, password);
            admin.Add(newUser);
            return newUser;
        }

        public string[] getAdminUserName()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var user in admin)
            {
                sb.Append(user.UserName);
                sb.Append("\n");
            }
            sb.Append("Exit");

            return sb.ToString().Split("\n");
            

        }

        public string[] getPostName(int choose) {
            StringBuilder sb = new StringBuilder();
            foreach (var user in admin)
            {
               if(user.Id-1 == choose) 
                for (int i = 0; i<user.Posts.Count; i++)
                {
                    

                    
                        sb.Append($"{user.Posts[i].Id}: {user.Posts[i].Title}");
                        sb.Append("\n");
                    
                }
            }
            sb.Append("Exit");

            return sb.ToString().Split("\n");
        }

        public string getText(int choose,int choose1)
        {
            foreach(var user in admin)
            {
                if (user.Id-1 == choose1)
                for (int i = 0;i<user.Posts.Count;i++)
                {
                    if (user.Posts[i] == user.Posts[choose])
                    {
                        user.Posts[i].ViewCount++;
                        return user.Posts[i].Content;

                    }

                }
            }
            
            throw new NotImplementedException("Invalid Choose");


        }


        public void LikeCount(int choose,User fromUser)
        {

            foreach (var user in admin)
            {
                for (int i = 0; i<user.Posts.Count; i++)
                {
                    if (user.Posts[i] == user.Posts[choose])
                    {
                        if (!(LikedPosts.ContainsKey(i) && LikedPosts[i]))
                        {
                            LikedPosts[i]=true;
                            user.addNotification(fromUser, "Like Post");
                            user.Posts[i].LikeCount++;
                            return;
                        }
                        else if (LikedPosts.ContainsKey(i) && LikedPosts[i])
                            return;
                            

                    }

                }
            }

            throw new NotImplementedException("Invalid Choose");

        }
    }
}
