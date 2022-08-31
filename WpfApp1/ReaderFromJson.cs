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
        public readonly string path = @"JSON/";
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
        public int aaa = 0;
        public List<User> ReadFromJsonFile()
        {
            //List<User>  = people; ;
            List<User> BigUser = new List<User>();
            string[] files = Directory.GetFiles(path);
         
            foreach (string document in files)
            {
                foreach (var line in document)
                {
                    using (StreamReader file = File.OpenText(document))
                    {

                        JsonSerializer serializer = new JsonSerializer();
                        people = (List<User>)serializer.Deserialize(file, typeof(List<User>));
                        // BigUser.Add(people);
                        aaa++;
                    }




                }
                
              

            }
                //using (StreamReader file = File.OpenText(@"JSON/day1.json"))
           
            return people;         
        }
    }
}
