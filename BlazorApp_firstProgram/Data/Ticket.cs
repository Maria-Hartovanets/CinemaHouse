using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Data
{
    public class Ticket 
    {
        static int index = 0;
        public int ID { get; set; }
        public string NameMovie { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }

        public string KindM { get; set; }
        public int Price { get; set; }

        public Ticket(string nameMovie = " ", string genre = " ", int rating = 0, int price = 100, string kindM = " ")

        {
            ++index;
            NameMovie = nameMovie;
            Genre = genre;
            Rating = rating;
            KindM = kindM;
            Price = price;
            ID = index;
        }

        public string StrInfoOnly()
        {
            return $"{NameMovie} {Genre} {Rating} {Price} {KindM}";
        }

        public string ToStrInfo()
        {
            return $"Name: { NameMovie}\t|\tGenre: {Genre}" +
                 $"\t|\tRating: {Rating}\t|\tPrice: {Price}\t|\tType: {KindM}";
        }

        public void ChangePrice(int value)
        {
            Price = value;
        }
    }
}
