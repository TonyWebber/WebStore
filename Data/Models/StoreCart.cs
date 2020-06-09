using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Models
{
    public class StoreCart
    {
        private readonly AppDBContent appDBContent;
        public StoreCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string StoreCartId { get; set; }
        public List<StoreCartItem> ListStoreItems { get; set; }

        public static StoreCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);

            return new StoreCart(context) { StoreCartId = shopCartId };

        }
        public void AddToCart(Car car)
        {
            this.appDBContent.StoreCartItems.Add(new StoreCartItem
            {
                StoreCartId = StoreCartId,
                Car = car,
                Price = car.Price

            });
            appDBContent.SaveChanges();
        }

        public List<StoreCartItem> GetStoreItems()
        {
            return appDBContent.StoreCartItems.Where(c => c.StoreCartId == StoreCartId).Include(s => s.Car).ToList();
        }
    }
}
