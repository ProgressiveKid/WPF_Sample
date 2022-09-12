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
        public int message = 0;
        // public static List<User> BigUser;
        public List<UserInTable> ReadFromJsonFile()
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


            List<string> name = new List<string>();

            foreach (User user in BigUser)
            {
                name.Add(user.UserName);


            } // Сформировали лист только из названии
            List <string> nameWithoutRepetition = name.Distinct().ToList(); // Убрали повторяющиеся имена
                                                                            // nameWithoutRepetition.ToArray();
            List<UserInTable> userInTables = new List<UserInTable>();
            
            foreach (string a in nameWithoutRepetition)
            {
                List<UserInTable> userInTablesForAdd1 = new List<UserInTable>()
                    {

                new UserInTable
                {
                UserName = a,
                 CountDay = 100,
                SumStepsDay = 100,
                  FinishSum = 100,
               MaxSum = 100,
             MinSum = 100,
                }
                };
                userInTables.Add(userInTablesForAdd1[0]);
            
            } // Добавили в не повторяющиеся значения в новый лист объектов 
          // --------------------------**Костыль ебаный!!!-----------
            
          

            for (int i = 0; i < nameWithoutRepetition.Count(); i++)
            {
                string nameA = nameWithoutRepetition[i];
                bool firstFind = false;
                
                foreach (User user in BigUser)
                {
                  
                    if (nameA == user.UserName && firstFind == false)
                    {
                        userInTables[i].UserName = nameA;
                        userInTables[i].CountDay = 1;
                        userInTables[i].SumStepsDay = user.Steps;
                        firstFind = true;
                    }
                    if (nameA == user.UserName && firstFind == true)
                    {
                        userInTables[i].CountDay++;
                        userInTables[i].SumStepsDay += user.Steps;

                    }

                }
            }
                        


            
          
            
           

            return userInTables;         
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
