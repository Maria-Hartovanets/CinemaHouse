using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BlazorApp_firstProgram.Data
{
    public class ServiseTicket
    {

        List<Ticket> ticketArr;
        readonly string filePath;
        readonly char delim;
     
        public ServiseTicket()
        {
            delim = ' ';
            
            filePath = @"D:\Programming\PersonalPractice\BlazorApp_firstProgram\BlazorApp_firstProgram\DataTxt\TicketFile.txt";

            ticketArr = new List<Ticket>();
            ReadItemsFromFile();
        }
        private void WriteToFile()
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                foreach (Ticket tick in ticketArr)
                {
                    streamWriter.WriteLine(tick.StrInfoOnly());
                }
            }
        }
      

        private void ReadItemsFromFile()
        {
            try
            {


                ticketArr.Clear();
                using (var streamReader = new StreamReader(filePath))
            {
                string fileLine;

                while ((fileLine = streamReader.ReadLine()) != null)
                {
                    string[] strObjItems = fileLine.Split(delim);
                    Ticket temp = ConvertToObject(strObjItems);
                    ticketArr.Add(temp);
                }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during read file: {ex.Message}");
            }
        }

     

         Ticket ConvertToObject(string[] strObjItems)
        {
            int fieldsCount = 5;

            if (strObjItems.Length != fieldsCount)
                throw new Exception("Line is in incorrect format!");
            int tempPrice = Convert.ToInt32(strObjItems[3]);
            int tempRating = Convert.ToInt32(strObjItems[2]);
            return new Ticket(strObjItems[0], strObjItems[1], tempRating, tempPrice, strObjItems[4]);
        }


        public List<Ticket> Array()
        {
            return ticketArr;
        }

        public void Add(Ticket temp)
        {
            ticketArr.Add(temp);
            using (StreamWriter streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default))
            {//only to add to the previous data file
                streamWriter.WriteLine(temp.StrInfoOnly());
            }
            ReadItemsFromFile();
        }
        public void ChangeValue(int tempNumber, int newPrice)
        {
            foreach (Ticket tickt in ticketArr)
            {
                if (tempNumber < tickt.Rating)
                {
                    tickt.ChangePrice(newPrice);
                }
            }
            WriteToFile();

        }


        public string PopularObjStr()
        {
            int maxRating = ticketArr[0].Rating;
            int i = 0;
            int index = 0;
            foreach (Ticket movie in ticketArr)
            {
                if (maxRating < movie.Rating)
                {
                    maxRating = movie.Rating;
                    index = i;
                }
                i++;
            }

            return ticketArr[index].ToStrInfo();

        }
        public int GetSizeArr()
        {
            return (ticketArr.Count == 0) ? ticketArr.Count : 0;
        }

        public void RemoveByIndex(int index)
        {
            index -= 1;
            ticketArr.RemoveAt(index);
            WriteToFile();
        }

        public void GetMetodToRead()
        {
            ReadItemsFromFile();
        }
    }
}

