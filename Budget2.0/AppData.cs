using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget2._0
{

    public class AppData
    {
        public List<Income> gains { get; set; }

        public List<Spending> losses { get; set; }
        public List<Category> categories { get; set; }
        public List<User> users { get; set; }
        protected const string GainsFileName = "data/gains.json";
        protected const string LossesFileName = "data/losses.json";
        protected const string CategoriesFileName = "data/categories.json";
        protected const string UsersFileName = "data/users.json";
        public void SaveData()
        {
            Serialize(UsersFileName, users);
            Serialize(GainsFileName, gains);
            Serialize(LossesFileName, losses);
            Serialize(CategoriesFileName, categories);
        }

        private void Serialize<T>(string fileName, T data)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, data);
                }
            }
        }
        
        public void GetIncomes(Income income)
        {
            gains.Add(income);
            SaveData();
        }
        public void GetSpendings(Spending spending)
        {
            losses.Add(spending);
            SaveData();
        }


        private T Deserialize<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
        // TODO Add files, check executability
        public void LoadData()
        {
            users = Deserialize<List<User>>(UsersFileName);
            gains = Deserialize<List<Income>>(GainsFileName);
            losses = Deserialize<List<Spending>>(LossesFileName);
            categories = Deserialize<List<Category>>(CategoriesFileName);
        }
        public AppData()
        {
            gains = new List<Income>();
            losses = new List<Spending>();
            categories = new List<Category>();
            users = new List<User>();
            LoadData();
            //TODO here we implement basic categories
        }


    }
}

