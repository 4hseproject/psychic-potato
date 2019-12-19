using System;
using System.Collections.Generic;
using System.Text;

namespace Budget2._0
{
    public class Factory
    {
        private static Factory instance;

        private Factory() { }
        public static Factory Instance
        {
            get
            {
                // Lazy initialization; initialization on demand
                if (instance == null)
                    instance = new Factory();
                return instance;
            }
        }
        private AppData appData;
        public AppData GetAppData()
        {
            return appData ?? (appData = new AppData());
        }
        private Calculations calculations;
        public Calculations GetCalculations()
        {
            appData = GetAppData();
            return calculations ?? (calculations = new Calculations(appData));
        }
    }
}
