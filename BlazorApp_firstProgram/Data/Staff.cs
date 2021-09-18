using System;

namespace BlazorApp_firstProgram.Data
{
    public class Staff
    {
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; } = 0;
        public string Roll { get; set; } = "";
        public int Rating { get; set; } = 0;
       
    }
}
