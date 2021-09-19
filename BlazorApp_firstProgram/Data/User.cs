using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Data
{
    public class User
    {
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string firstname { get; set; } = "";
        public string lastname { get; set; } = "";
        public int age { get; set; } = 0;
        public string hometown { get; set; } = "";
        public string Password { get; set; } = "";

    }
}
