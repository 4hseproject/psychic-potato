using System;
using System.Collections.Generic;
using System.Text;

namespace Budget2._0
{
    public interface IRepository<T>
    {
        IEnumerable<T> Items { get; }

        void Add(T item);
        void Remove(T item);
        public IEnumerator<T> GetEnumerator();
    }
    public class ListRepository<T> : IRepository<T>
    {
        private List<T> items { get; set; }
        public IEnumerable<T> Items => items;

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }
        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();
    }
        public interface IAppData
    {
        public IRepository<Income> gains { get; }
        public IRepository<Spending> losses { get; }
        public IRepository<Category> categories { get; }

    }
    public abstract class BaseAppData : IAppData
    {
        public IRepository<Income> gains { get; set; }

        public IRepository<Spending> losses { get; set; }
        public IRepository<Category> categories { get; set; }
    }
    public class WindowAppData : BaseAppData
    {
        public WindowAppData()
        {
            gains = new ListRepository<Income>();

            losses = new ListRepository<Spending>();
            categories = new ListRepository<Category>();
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
