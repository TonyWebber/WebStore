using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllorders allorders;
        private readonly StoreCart storeCart;
        public OrderController(IAllorders allorders, StoreCart storeCart)
        {
            this.allorders = allorders;
            this.storeCart = storeCart;
        }

        public IActionResult Checkout()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            storeCart.ListStoreItems = storeCart.GetStoreItems();
            if(storeCart.ListStoreItems.Count == 0)
            {
                ModelState.AddModelError("","You should add to cart something!");
            }
            if (ModelState.IsValid)
            {
                allorders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order complete! Our manager will call You soon. Thanks.";
            return View();
        }
    }
}
