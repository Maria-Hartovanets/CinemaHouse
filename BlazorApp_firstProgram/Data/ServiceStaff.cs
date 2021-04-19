using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace BlazorApp_firstProgram.Data
{
    public class ServiceStaff
    {
        List<Staff> staffArr;
        readonly string filePath;
        readonly char delim;


        public ServiceStaff()
        {
            delim = ' ';

            filePath = @"D:\Programming\PersonalPractice\BlazorApp_firstProgram\BlazorApp_firstProgram\DataTxt\StaffFile.txt";

            staffArr = new List<Staff>();
            ReadItemsFromFile();

        }
        private void WriteToFile()
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                foreach (Staff person in staffArr)
                {
                    streamWriter.WriteLine(person.StrInfo());
                }
            }
        }
      
        private void ReadItemsFromFile()
        {
            try
            {

                staffArr.Clear();
                using (var streamReader = new StreamReader(filePath))
                {
                    string fileLine;

                    while ((fileLine = streamReader.ReadLine()) != null)
                    {
                        string[] strObjItems = fileLine.Split(delim);
                        Staff temp = ConvertToObjectStaff(strObjItems);
                        staffArr.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during read file: {ex.Message}");
            }
        }
        

        Staff ConvertToObjectStaff(string[] strObjItems)
        {
            int fieldsCount = 5;

            if (strObjItems.Length != fieldsCount)
                throw new Exception("Line is in incorrect format!");
            int tempAge = Convert.ToInt32(strObjItems[3]);
            int tempRating = Convert.ToInt32(strObjItems[4]);
            return new Staff(strObjItems[0], strObjItems[1], strObjItems[2], tempAge, tempRating);
        }

        public void Add(Staff temp)
        {
            staffArr.Add(temp);
            using (StreamWriter streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default))
            {//only to add to the previous data file
                streamWriter.WriteLine(temp.StrInfo());
            }
            ReadItemsFromFile();
        }

        public List<Staff> Array()
        {
            return staffArr;
        }

        public void ChangeValue(int tempNumber, string newValue)
        {
            foreach (Staff person in staffArr)
            {
                if (tempNumber == person.Rating)
                {
                    person.ChangeValue(newValue);
                }
            }
            WriteToFile();
           
        }

        public string PopularObjIndex()
        {
            int maxRating = staffArr[0].Rating;
            int i = 0;
            int index = 0;
            foreach (Staff person in staffArr)
            {
                if (maxRating < person.Rating)
                {
                    maxRating = person.Rating;
                    index = i;
                }
                i++;
            }
            return staffArr[index].StringInfo();
        }

        public void RemoveByIndex(int index)
        {
            index -= 1;
            staffArr.RemoveAt(index);
            WriteToFile();
        }
        public void GetMetodToRead()
        {
            ReadItemsFromFile();
        }

    }
}
