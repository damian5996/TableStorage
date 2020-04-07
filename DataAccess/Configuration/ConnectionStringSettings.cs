﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class ConnectionStringSettings
    {
        public string LocalDB { get; set; }
        public string AzureTableStorage => Environment.GetEnvironmentVariable("APPSETTING_AzureTableStorage");
    }
}
