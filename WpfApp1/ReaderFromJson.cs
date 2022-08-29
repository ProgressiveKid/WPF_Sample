using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WpfApp1
{
    internal class ReaderFromJson
    {
        public readonly string path = "JSON\\";
        public string ReadFromFile()
        {
            string a = "";
            int ab = 1;
            //string[] lines = File.ReadAllLines(path);
            if (Directory.Exists(path))
            {

                a = "net";
                string[] files = Directory.GetFiles(path);
                foreach (string liness in files)
                {
                    
                }

            }
            else a = "lf";
        
          
            return Convert.ToString(a+ab);
        }

        public void ReadFromJsonFile()
        {
            string[] files = Directory.GetFiles(path);


            
            List<User> ListUser = new List<User>(); // Сделали лист с юзерами
            foreach (string item in files) // Перебираем папку с JSON
            {
                string[] lines = File.ReadAllLines(item); //считываем линни в выбраном JSON
                //User user = new User();
               
                List<User> items = JsonConvert.DeserializeObject<List<User>>(path);
                //ListUser.Add(items);
            }

          //  return sbyte;
        }
    }
}
