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
       // public static List<User> BigUser;
        public List<User> ReadFromJsonFile() 
        {
            List<User> BigUser = new List<User>();
            string[] files = Directory.GetFiles(path);
            foreach (var document in files)
            {
                using (StreamReader file = File.OpenText(document))
                {

                    JsonSerializer serializer = new JsonSerializer();
                    people = (List<User>)serializer.Deserialize(file, typeof(List<User>));
                    foreach (var ass in people)
                    {
                        BigUser.Add(ass);
                    }
                }
                
            } // Сформировали из JSON List<User>
              //using (StreamReader file = File.OpenText(@"JSON/day1.json"))
       
            List<string> name = new List<string>();
            List<User> BigUser1 = new List<User>();
            foreach (User user in BigUser)
            {
                name.Add(user.UserName);
            
            } // Сформировали лист только из названии
            var nameWithoutRepetition = name.Distinct(); // Убрали повторяющиеся имена
            nameWithoutRepetition.ToList();
            foreach (User user1 in BigUser1)
            {
                
                foreach (string A in user1.UserName)
                {
                    BigUser1.Add(A);
                    if (user1.UserName == A)
                    {


                    }
                    else
                    { 
                    
                    
                    }


                }
               

            }

            return BigUser;         
        } public void ReadFromJsonFile(User user)
        {
            
            // BigUser.Add(people);
            string[] files = Directory.GetFiles(path);
            foreach (string document in files)
            {
                using (StreamReader file = File.OpenText(document))
                {
                    string readerFromJsonFile = File.ReadAllText(document);
                   
                    //user = JsonSerializer.Deserialize<User>(readerFromJsonFile);
                    // BigUser.Add(people);
                }

            }
                
           
                   
        }

        public void ProvideFromJSON()
        {
            
        
        }
    }
}
