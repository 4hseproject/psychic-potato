using System;

namespace Budget2._0
{
    public interface IFlow
    {
        public decimal Amount { get; set; }
        public Category Category { get; set; }
        public string Comment { get; set; }
        public int UID { get; set; }
        public int CatId { get; set; }
    }
}
