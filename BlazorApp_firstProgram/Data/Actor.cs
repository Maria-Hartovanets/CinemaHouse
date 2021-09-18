using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Data
{
     public class Actor
    {
       
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string HomeTown { get; set; } = "";
        public int CountOfMovie { get; set; } = 0;
        public int Rating { get; set; } = 1;

        
    }
}
