using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopkeeperApi.Entities
{
    public class RequestChangeStatus
    {
        public string status { get; set; }

        public RequestChangeStatus(string status)
        {
            this.status = status;
        }
    }
}
