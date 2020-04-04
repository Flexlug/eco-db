using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eco_db_backend.Models
{
    public class Product
    {
        public object _id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string BarcodeType { get; set; }
        public string BarcodeValue { get; set; }
        public List<PartInfo> PackageInfo { get; set; }
    }
}
