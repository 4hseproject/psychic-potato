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
    }
    public class ListRepository<T> : IRepository<T> where T :IFlow
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
    }
    public interface IAppData
    {
        public IRepository<Income> gains { get; }
        public IRepository<Spending> loses { get; }

    }
    public abstract class BaseAppData : IAppData
    {
        public IRepository<Income> gains { get; set; }

        public IRepository<Spending> loses { get; set; }
    }
    public class WindowAppData : BaseAppData
    {
        public WindowAppData()
        {
            gains = new ListRepository<Income>();

            loses = new ListRepository<Spending>();
        }

        public void GetIncomes(Income income)
        {
            gains.Add(income);
        }
        public void GetSpendings(Spending spending)
        {
            loses.Add(spending);
        }
    }
    public class Calculations
    {
        private WindowAppData Data { get; set; }
        public Calculations(WindowAppData data)
        {
            Data = data;
        }
        public decimal GetAverage(WindowAppData data)
        {
            throw new NotImplementedException();
        }
        // all logic functions go here 
    }
}
