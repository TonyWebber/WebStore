using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car> 
                {
                    new Car 
                    { 
                        Name = "Tesla S", 
                        ShortDescription = "Future is here",
                        LongDescription = "Beautiful, fast and very silent vehicle by company Tesla",
                        Img = "https://static.turbosquid.com/Preview/001144/484/DR/3D-tesla-s-100d-2015-model_DHQ.jpg",
                        Price = 45000, 
                        IsFavourite = true, 
                        Available = true, 
                        Category = _categoryCars.AllCategories.First() 
                    },
                    new Car
                    {
                        Name = "Ford Mondeo",
                        ShortDescription = "Silent and calm",
                        LongDescription = "Comfortable vehicle for urban",
                        Img = "https://st.motortrend.com/uploads/sites/10/2015/11/2014-ford-fusion-se-hybrid-sedan-angular-front.png",
                        Price = 15000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "BMW X6",
                        ShortDescription = "Fast and Furious",
                        LongDescription = "The BMW X6 is a mid-size luxury crossover by German automaker BMW.",
                        Img = "https://cars.usnews.com/static/images/Auto/izmo/i5356796/2017_bmw_x6_m_angularfront.jpg",
                        Price = 65000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescription = "Silent and economic",
                        LongDescription = "Convenient vehicle for living in the city",
                        Img = "https://patrioty.org.ua/images/2019/08/22180857_issaneaf_201112.png",
                        Price = 14000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "Mercedes S500",
                        ShortDescription = "Premium and splendid",
                        LongDescription = "Convenient vehicle for living in the city",
                        Img = "https://megarent.ua/style/img/news/36.png",
                        Price = 55000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }
        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
