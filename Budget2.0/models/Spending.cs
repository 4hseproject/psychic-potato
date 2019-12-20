using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget2._0
{
    public class Spending : IFlow
    {
        public decimal Amount { get ;set; }
        [JsonIgnore]
        public Category Category { get;  set; }
        public string Comment { get ; set; }
        public int UID { get ; set; }
        public int CatId { get; set; }
        public DateTime TransactionDt { get ; set; }

        public Spending(decimal Amount, Category category, string comment, int UID, int CatId, DateTime dt)
        {
            this.Amount = Amount;
            this.Category = category;
            this.Comment = comment;
            this.UID = UID;
            this.CatId = CatId;
            this.TransactionDt = dt;
        }
    }
}
