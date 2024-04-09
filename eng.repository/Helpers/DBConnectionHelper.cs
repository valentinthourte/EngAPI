using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace eng.repository.Helpers
{
    internal static class DBConnectionHelper
    {
        public static string getConnectionString(string DBName = "")
        {
            using IHost host = Host.CreateDefaultBuilder().Build();

            var config = host.Services.GetService(typeof(IConfiguration)) as IConfiguration;

            string cnxStr = config.GetConnectionString("DefaultConnection") ?? "";
            return cnxStr.Replace("%s", DBName);
        }
    }
}
