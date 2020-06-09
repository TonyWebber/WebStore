using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Data.Repos
{
    public class OrdersRepos : IAllorders
    {
        private readonly AppDBContent appDBContent;
        private readonly StoreCart storeCart;
        public OrdersRepos(AppDBContent appDBContent, StoreCart storeCart)
        {
            this.appDBContent = appDBContent;
            this.storeCart = storeCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();


            var items = storeCart.ListStoreItems;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);

            }
            appDBContent.SaveChanges();
        }
    }
}
