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
                List<User> ListUser = new List<User>();
                User user = JsonConvert.DeserializeObject<User>(path);
                a = "net";
                string[] files = Directory.GetFiles(path);
                foreach (string liness in files)
                {
                    
                }

            }
            else a = "lf";
        
          
            return Convert.ToString(a+ab);
        }

      
        public static List<User> people;
        public List<User> ReadFromJsonFile()
        {
            List<User> BigUser;
            string[] files = Directory.GetFiles(path);
            foreach (var document in files)
            {
                using (StreamReader file = File.OpenText(document))
                {

                    JsonSerializer serializer = new JsonSerializer();
                    people = (List<User>)serializer.Deserialize(file, typeof(List<User>));
                   // BigUser.Add(people);
                }

            }
                //using (StreamReader file = File.OpenText(@"JSON/day1.json"))
           
            return people;         
        }
    }
}
