using System;

namespace BlazorApp_firstProgram.Data
{
    public class Staff
    {
        static int index = 0;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public int Rating { get; set; }
        public Staff(string firstName = "", string lastName = "", string workType="",int age = 0, int rating = 0)
        {
            ++index;
            FirstName = firstName;
            LastName = lastName;
            Type = workType;
            Age = age;
            Rating = rating;
            ID = index;
        }

        public string StringInfo()
        {
            return ($"First name: {FirstName}\t|\tLast name: {LastName}\t|\tWork: {Type}" +
                $"\t|\tAge: {Age}\t|\tRating: {Rating}");
        }

        public void ChangeValue(string value)
        {
            Rating = Convert.ToInt32(value);
        }

        public string StrInfo()
        {
            return $"{FirstName} {LastName} {Type} {Age} {Rating}";
        }
    }
}
