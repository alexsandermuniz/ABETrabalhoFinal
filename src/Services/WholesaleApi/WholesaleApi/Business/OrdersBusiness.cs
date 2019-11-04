using WholesaleApi.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using WholesaleApi.Utils;
using Newtonsoft.Json;

namespace WholesaleApi.Business
{
    
    public class OrdersBusiness
    {
        private static long contMockId = 100;
        public static List<Order> ordersMock = new List<Order>();

        public double randomNumber(int quant)
        {
            Random r = new Random();
            double n = r.NextDouble();
            double rand = 1000* round(n,2) * quant;
            return rand;
        }
        public Budget createBudgetWithOrders(List<Order> orders)
        {
            int qtd = 0;
            foreach(Order ord in orders)
            {
                ord.id = contMockId++;
                ordersMock.Add(ord);
                qtd += ord.quantity;
            }

            Budget budget = new Budget();
            budget.orders = orders;
            budget.date = DateTime.Now;
            budget.customer = orders.FirstOrDefault().storeName;
            budget.value = randomNumber(qtd);
            budget.status = "";
            BudgetsBusiness.addBudget(budget);

            return budget;
        }
        public Order getOrder(long oderId)
        {
            return ordersMock.Where(x => x.id == oderId).FirstOrDefault();
        }
        public List<Order> getOrders()
        {
            return ordersMock;
        }
       

        public static double round(double value, int places)
        {
            if (places < 0) return 0;

            long factor = (long)Math.Pow(10, places);
            value = value * factor;
            double tmp = Math.Round(value);
            return tmp / factor;
        }
    }

}


