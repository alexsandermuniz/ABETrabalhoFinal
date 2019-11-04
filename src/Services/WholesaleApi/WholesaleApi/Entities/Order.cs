﻿namespace WholesaleApi.Entities
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
