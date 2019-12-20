using Budget2._0.models;
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
                var spending = new Spending(amount,category,comment,user.UID,category.ID,DateTime.Now);
                Data.GetSpendings(spending);
                user.OverallBalance -= amount;
                Data.SaveData();
                
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
                income.TransactionDt = DateTime.Now;
                Data.GetIncomes(income);
                user.OverallBalance += amount;
                Data.SaveData();
                
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
        public bool AddUser(string login, string password, decimal balance, string answer, string question)
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
            user.Answer = answer;
            user.Question = question;
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
        // following function is written with the inspiration from https://www.geeksforgeeks.org/shellsort/
        public List<IFlow> SortByDate(List<IFlow> flows)
        {
            int n = flows.Count;

            // Start with a big gap,  
            // then reduce the gap 
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size. 
                // The first gap elements a[0..gap-1] are already 
                // in gapped order keep adding one more element 
                // until the entire array is gap sorted 
                for (int i = gap; i < n; i += 1)
                {
                    // add a[i] to the elements that have 
                    // been gap sorted save a[i] in temp and 
                    // make a hole at position i 
                    DateTime temp = flows[i].TransactionDt;
                    IFlow interim = flows[i];

                    // shift earlier gap-sorted elements up until 
                    // the correct location for a[i] is found 
                    int j;
                    for (j = i; j >= gap && DateTime.Compare(flows[j - gap].TransactionDt, temp) < 0 ; j -= gap)
                        flows[j] = flows[j - gap];

                    // put temp (the original a[i])  
                    // in its correct location 
                    flows[j] = interim;
                }
            }
            return flows;
        }
        public List<DataVisualisationNoCatSelection> SortByDate(List<DataVisualisationNoCatSelection> flows)
        {
            int n = flows.Count;

            // Start with a big gap,  
            // then reduce the gap 
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size. 
                // The first gap elements a[0..gap-1] are already 
                // in gapped order keep adding one more element 
                // until the entire array is gap sorted 
                for (int i = gap; i < n; i += 1)
                {
                    // add a[i] to the elements that have 
                    // been gap sorted save a[i] in temp and 
                    // make a hole at position i 
                    DateTime temp = flows[i].Date;
                    DataVisualisationNoCatSelection interim = flows[i];

                    // shift earlier gap-sorted elements up until 
                    // the correct location for a[i] is found 
                    int j;
                    for (j = i; j >= gap && DateTime.Compare(flows[j - gap].Date, temp) < 0; j -= gap)
                        flows[j] = flows[j - gap];

                    // put temp (the original a[i])  
                    // in its correct location 
                    flows[j] = interim;
                }
            }
            return flows;
        }

        public string Qestion_per_login(string login) 
        {
            foreach (var user  in Data.users)
            {
                if (user.Login == login)
                {
                    return user.Question;
                }
            }
            return null;
        }

        public string Answer_per_login(string login)
        {
            foreach (var user in Data.users)
            {
                if (user.Login == login)
                {
                    return user.Answer;
                }
            }
            return null;
        }

        public string Password_per_login(string login)
        {
            foreach (var user in Data.users)
            {
                if (user.Login == login)
                {
                    return user.Password;
                }
            }
            return null;
        }

        public User Changebudgetname(User u , string login, decimal budget)
        {
            foreach (var user in Data.users)
            {
                if (u == user)
                {
                    user.Login = login;
                    user.OverallBalance = budget;
                    Data.SaveData();
                    return user;
                }
            }
            return null;
        }

        public User Changepassword(User u, string password)
        {
            foreach (var user in Data.users)
            {
                if (u == user)
                {
                    user.Password = password;
                    Data.SaveData();
                    return user;
                }
            }
            return null;
        }

        //TODO all logic functions go here 
    }
}
