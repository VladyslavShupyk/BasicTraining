using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET02._4
{
    class SiteData
    {
        public int PingInterval { get; set; }
        public int ServerResponseTime { get; set; }
        public string SiteUrl { get; set; }
        public string AdminEmail { get; set; }
        public SiteData(int pingInterval, int serverResponseTime, string siteUrl, string adminEmail)
        {
            PingInterval = pingInterval;
            ServerResponseTime = serverResponseTime;
            SiteUrl = siteUrl;
            AdminEmail = adminEmail;
        }
    }
}
