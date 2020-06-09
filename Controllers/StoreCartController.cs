using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class StoreCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly StoreCart _storeCart;
        
        public StoreCartController(IAllCars carRep, StoreCart storeCart)
        {
            _carRep = carRep;
            _storeCart = storeCart;
        }

        public ViewResult Index()
        {
            var items = _storeCart.GetStoreItems();
            _storeCart.ListStoreItems = items;
            var obj = new StoreCartViewModel
            {
                StoreCart = _storeCart
            };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
            if(item != null)
            {
                _storeCart.AddToCart(item);
            }
            return RedirectToAction("Index");

        }
    }
}
