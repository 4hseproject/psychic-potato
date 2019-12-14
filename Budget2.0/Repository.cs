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
    public class ListRepository<T> : IRepository<T>
    {
        public List<T> items { get; set; }
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
}
