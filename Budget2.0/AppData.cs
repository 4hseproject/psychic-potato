using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget2._0
{
    public interface IAppData
    {
        public IRepository<Income> gains { get; }
        public IRepository<Spending> losses { get; }
        public IRepository<Category> categories { get; }
        public IRepository<User> users { get; }
        void SaveData();
        void GetSpendings(Spending spending);
        void GetIncomes(Income income);

    }
    public abstract class BaseAppData : IAppData
    {
        public IRepository<Income> gains { get; set; }

        public IRepository<Spending> losses { get; set; }
        public IRepository<Category> categories { get; set; }
        public IRepository<User> users { get; set; }
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
    }
    public class WindowAppData : BaseAppData
    {
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
        private void LoadData()
        {
            users = Deserialize<ListRepository<User>>(UsersFileName);
            gains = Deserialize<ListRepository<Income>>(GainsFileName);
            losses = Deserialize<ListRepository<Spending>>(LossesFileName);
            categories = Deserialize<ListRepository<Category>>(CategoriesFileName);
        }
        public WindowAppData()
        {
            gains = new ListRepository<Income>();
            losses = new ListRepository<Spending>();
            categories = new ListRepository<Category>();
            users = new ListRepository<User>();
            LoadData();
            //TODO here we implement basic categories
        }


    }
}
