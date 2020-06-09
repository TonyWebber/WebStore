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
    public class CarsController : Controller
    {
        private readonly IAllCars allCars;
        private readonly ICarsCategory allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            allCars = iAllCars;
            allCategories = iCarsCat;
        }
        
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = allCars.Cars.OrderBy(c => c.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(c => c.Category.Name.Equals("Electric cars")).OrderBy(c => c.Id);
                    currCategory = "Electro cars";
                }
                else 
                {
                    cars = allCars.Cars.Where(c => c.Category.Name.Equals("Cars")).OrderBy(c => c.Id);
                    currCategory = "Fuel cars";
                }
                
                
            }
            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                CurrCategorry = currCategory
            };
            ViewBag.Title = "Car's Page"; 
            return View(carObj);
        }
    }
}
