using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget2._0
{
    public class User
    {
        [JsonProperty]
        public string Login { get; set; }
        [JsonProperty]
        public string Password { get; set; }
        [JsonProperty]
        public int UID { get; set; }
        [JsonProperty]
        public decimal OverallBalance { get; set; }
        [JsonProperty]
        public string Answer { get; set; }
        [JsonProperty]
        public string Question { get; set; }

    }
}
