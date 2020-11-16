using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Histocity_Website.Models
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string histocity_db { get; set; }

    }
}
