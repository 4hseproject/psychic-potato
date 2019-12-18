using System;
using System.Collections.Generic;
using System.Text;

namespace Budget2._0
{
    public class Spending : IFlow
    {
        public decimal Amount { get ;set; }
        public Category Category { get;  set; }
        public string Comment { get ; set; }
        public int UID { get ; set; }
    }
}
