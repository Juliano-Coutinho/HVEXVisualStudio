using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVEXText.Data.Config
{
    public class HvexTesteDatabaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string[]? HvexTesteCollectionName { get; set; }
    }
}