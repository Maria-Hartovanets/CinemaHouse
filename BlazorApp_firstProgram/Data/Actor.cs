using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_firstProgram.Data
{
     public class Actor
    {
       static int index=0;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeTown { get; set; }
        public int CountOfMovie { get; set; }
        public int Rating { get; set; }

        public Actor(string firstName = "",string lastName="", string homeTown = "", int counrOfMovie = 0, int rating = 0)

        {
            ++index;
            FirstName = firstName;
            LastName = lastName;
            HomeTown = homeTown;
            CountOfMovie = counrOfMovie;
            Rating = rating;
            ID = index;

        }
        
        public string StrInfoOnly()
        {
            return $"{FirstName} {HomeTown} {CountOfMovie} {Rating}";
        }
        //public  string ToString()
        //{
        //    return ($"Name: {FirstName}\t|\tHome Town: {HomeTown}" +
        //         $"\t|\tAct in movies: {CountOfMovie}\t|\tRating: {Rating}");
        //}

        public void ChangeValue(int value)
        {
            throw new NotImplementedException();
        }
    }
}
