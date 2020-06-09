using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Models
{
    public class StoreCartItem
    {

        public int ID { get; set; }
        public Car Car { get; set; }
        public int Price { get; set; }
        public string StoreCartId { get; set; }
    }
}
