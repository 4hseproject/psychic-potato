using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget2._0
{
    public interface IRepository<T>: IEnumerable<T>
    {
        IEnumerable<T> Items { get; }

        void Add(T item);
        void Remove(T item);
    }
    public class ListRepository<T> : IRepository<T>
    {
        private List<T> items =  new List<T>();
        public IEnumerable<T> Items => items;

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items?.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
        public interface IAppData
    {
        public IRepository<Income> gains { get; }
        public IRepository<Spending> losses { get; }
        public IRepository<Category> categories { get; }
        public IRepository<User> users { get; }

    }
    public abstract class BaseAppData : IAppData
    {
        public IRepository<Income> gains { get; set; }

        public IRepository<Spending> losses { get; set; }
        public IRepository<Category> categories { get; set; }
        public IRepository<User> users { get; set; }
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
        private const string GainsFileName = "data/gains.json";
        private const string LossesFileName = "data/losses.json";
        private const string Categories = "data/Categories.json";
        private const string UsersFileName = "data/users.json";
        private void LoadData()
        {
            
        }

        private void SaveData()
        {
            
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
        public WindowAppData()
        {
            gains = new ListRepository<Income>();

            losses = new ListRepository<Spending>();
            categories = new ListRepository<Category>();
            users = new ListRepository<User>();
            //TODO here we implement basic categories
        }

        public void GetIncomes(Income income)
        {
            gains.Add(income);
        }
        public void GetSpendings(Spending spending)
        {
            losses.Add(spending);
        }
    }
    public class Calculations
    {
        private IAppData Data { get; set; }
        public Calculations(IAppData data)
        {
            Data = data;
        }
        public Category GetCategory(string name)
        {
            foreach (Category el in Data.categories)
            {
                if (el.Name == name)
                    return el;
            }
            return null;
        }
        public void AddFlow(decimal amount, Category category,string comment, bool IsSpending)
        {
            if (IsSpending)
            {
                var spending = new Spending();
                spending.Category = category;
                spending.Amount = amount;
                spending.Comment = comment;
                Data.losses.Add(spending);
            }
            else
            {
                var income = new Income();
                income.Category = category;
                income.Amount = amount;
                income.Comment = comment;
                Data.gains.Add(income); 
            }
        }
        public void AddUser(string login, string password, int balance)
        {
            int id;
            int max = 0; 
                foreach (User el  in Data.users)
                {
                    if (el.UID > max)
                    {
                        max = el.UID;
                    }
                }
            
            id = max + 1;
            var user = new User();
            user.UID = id;
            user.OverallBalance = balance;
            user.Login = login;
            user.Password = password;
            Data.users.Add(user);
        }
        public User CheckLogin(string login, string password)
        {
            foreach (User el in Data.users)
            {
                if (el.Login == login)
                    if (el.Password == password)
                        return el;

            }
            return null;
        }
        public decimal GetAverage(WindowAppData data)
        {
            throw new NotImplementedException();
        }
        public decimal GetSmthingbyDate(WindowAppData data, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
        public List<List<decimal>> ThisIsProbablyForGraphs ()
        {
            throw new NotImplementedException();
        }
        //TODO all logic functions go here 
    }
}
