using System;
using System.Collections.Generic;
using System.Text;

namespace Budget2._0.models
{
    public class DataVisualisationGeneral
    {
        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
    public class DataVisualisationNoCatSelection:DataVisualisationGeneral
    {
        
        public string CategoryName { get; set; }
        public DataVisualisationNoCatSelection(string amount, DateTime date, string CategoryName)
        {
            this.Amount = amount;
            this.Date = date;
            this.CategoryName = CategoryName;
        }
    }
}
