using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopkeeperApi.Entities
{
    public class Order
    {
        public long id { get; set; }
        public string storeName { get; set; }
        public int quantity { get; set; }
        public int productCode { get; set; }
        public string observation { get; set; }
    }
}
