using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget2._0
{
    public class Income : IFlow
    {
        public decimal Amount { get ; set ; }
        [JsonIgnore]
        public Category Category { get ; set ; }
        public string Comment { get ; set ; }
        public int UID { get ; set ; }
        public int CatId { get; set; }
    }
}
