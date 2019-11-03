using WholesaleApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreApi.Business
{
    
    public class OrdersBusiness
    {
        private static long contMockId = 100;
        public static List<Order> ordersMock = new List<Order>();
        public long addOrder(Order order)
        {
            order.id = contMockId;
            ordersMock.Add(order);
            return contMockId++;
        }
        public long addAllOrders(List<Order> orders)
        {
            foreach(Order ord in orders)
            {
                ordersMock.Add(ord);
            }
            return 0;
        }
        public Order getOrder(long oderId)
        {
            return ordersMock.Where(x => x.id == oderId).FirstOrDefault();
        }
        public List<Order> getOrders()
        {
            return ordersMock;
        }
    }

}


