using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace BlazorApp_firstProgram.Data
{
    public class ServiceActor
    {
       
        List<Actor> actorArr;
        readonly string filePath;
        readonly char delim;
       

        public ServiceActor()
        {
            delim = ' ';
           
            filePath = @"D:\Programming\PersonalPractice\BlazorApp_firstProgram\BlazorApp_firstProgram\DataTxt\ActorFile.txt";

            actorArr = new List<Actor>();
            ReadItemsFromFile();
        }
        private void WriteToFile()
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                foreach (Actor tick in actorArr)
                {
                    streamWriter.WriteLine(tick.StrInfoOnly());
                }
            }
        }
      
        private void ReadItemsFromFile()
        {
            try
            {
                actorArr.Clear();
                using (var streamReader = new StreamReader(filePath))
                {
                    string fileLine;


                    while ((fileLine = streamReader.ReadLine()) != null)
                    {
                        string[] strObjItems = fileLine.Split(delim);
                        Actor temp = ConvertToObject(strObjItems);
                        actorArr.Add(temp);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error during read file: {ex.Message}");
            }
        }

       

         Actor ConvertToObject(string[] strObjItems)
        {
            int fieldsCount = 5;

            if (strObjItems.Length != fieldsCount)
                throw new Exception("Line is in incorrect format!");
            int tempCountMow = Convert.ToInt32(strObjItems[3]);
            int tempRating = Convert.ToInt32(strObjItems[4]);
            return new Actor(strObjItems[0], strObjItems[1], strObjItems[2], tempCountMow, tempRating);
        }


        public List<Actor> Array()
        {
            return actorArr;
        }

        public void Add(Actor temp)
        {
            actorArr.Add(temp);
            using (StreamWriter streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default))
            {//only to add to the previous data file
                streamWriter.WriteLine(temp.StrInfoOnly());
            }
            ReadItemsFromFile();
        }
        public void ChangeValue(int tempNumber, int value)
        {
            foreach (Actor actor in actorArr)
            {
                if (tempNumber < actor.Rating)
                {
                    actor.ChangeValue(value);
                }
            }
            WriteToFile();

        }

        public string PopularObjStr()
        {
            int maxRating = actorArr[0].Rating;
            int i = 0;
            int index = 0;
            foreach (Actor actor in actorArr)
            {
                if (maxRating < actor.Rating)
                {
                    maxRating = actor.Rating;
                    index = i;
                }
                i++;
            }
            return actorArr[index].ToString();
        }


        //public void RemoveByIndex(int index)
        //{
        //    index -= 1;
        //    actorArr.RemoveAt(index);
        //    WriteToFile();
        //}
        public void GetMetodToRead()
        {
            ReadItemsFromFile();
        }
    }
}
