using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Data
{
    public class Post
    {
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string TitlePost { get; set; } = "";
        public string TextForPost { get; set; } = "";
        public string Image { get; set; } = "";
        public int Likes { get; set; } = 0;
        
        public void AddLike()
        {
            Likes += 1;
        }
    }
}
