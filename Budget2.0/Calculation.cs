using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget2._0
{
     
    public class Calculations
    {
        private AppData Data { get; set; }
        public Calculations(AppData data)
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
        public User AddFlow(decimal amount, Category category,string comment, bool IsSpending, User user)
        {
            // TODO add data attribute to the IFlow interface, so we can plot graphs using that data
            if (IsSpending)
            {
                var spending = new Spending(amount,category,comment,user.UID,category.ID);
                Data.GetSpendings(spending);
                Data.SaveData();
                user.OverallBalance -= amount;
                return user;
            }
            else
            {
                var income = new Income();
                income.Category = category;
                income.Amount = amount;
                income.Comment = comment;
                income.UID = user.UID;
                income.CatId = category.ID;
                Data.GetIncomes(income);
                Data.SaveData();
                user.OverallBalance += amount;
                return user;
            }
        }
        public decimal CalculateBalance(decimal balance, decimal amount, bool IsSpending)
        {
            if (IsSpending)
                return balance - amount;
            else
                return balance + amount;
        }
        public bool AddUser(string login, string password, decimal balance)
        {
            int id;
            int max = 0; 
                foreach (User el  in Data.users)
                {
                    if (el.UID > max)
                    {
                        max = el.UID;
                    }
                    if (el.Login == login)
                { return false; }
                        
                }
            
            id = max + 1;
            var user = new User();
            user.UID = id;
            user.OverallBalance = balance;
            user.Login = login;
            user.Password = password;
            Data.users.Add(user);
            Data.SaveData();
            return true;
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
        public decimal GetAverage(AppData data)
        {
            throw new NotImplementedException();
        }
        public decimal GetSmthingbyDate(AppData data, DateTime start, DateTime end)
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
