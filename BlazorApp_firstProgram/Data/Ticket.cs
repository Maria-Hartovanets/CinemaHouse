namespace BlazorApp_firstProgram.Data
{
    public class Ticket 
    {
       
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string NameMovie { get; set; } = "";
        public string Genre { get; set; } = "";
        public int Rating { get; set; } = 0;

        public string KindM { get; set; } = "";
        public int Price { get; set; } = 0;

       
    }
}
