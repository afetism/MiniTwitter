using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Posts
{
    //Post=>id,Content,CreationDateTime,LikeCount,ViewCount
    internal class Post
    {
        static int id = 0;

        public Post(string content, string title)
        {
            Content=content;
            Title=title;
        }

        public int Id { get; } = ++id;

        public string Content { get; private set; }
        public string Title { get; private set; }
        public string CreationDateTime { get; private set; } = DateTime.Now.ToString("dd.MM.yyyy");
        public int LikeCount { get;set; } = 0;

        public int ViewCount { get; set; } = 0;


    }
}
