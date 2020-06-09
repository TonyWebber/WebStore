using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Models;

namespace WebStore.Data.Interfaces
{
    public interface IAllorders
    {
        void CreateOrder(Order order);
    }
}
