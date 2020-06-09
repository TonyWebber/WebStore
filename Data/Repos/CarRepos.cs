using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Data.Repos
{
    public class CarRepos : IAllCars
    {
        private readonly AppDBContent appDBContent;
        public CarRepos(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);
        public IEnumerable<Car> GetFavCars => appDBContent.Car.Include(c => c.Category).Where(c => c.IsFavourite == true); //Where(c => c.IsFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carID) => appDBContent.Car.FirstOrDefault(c => c.Id == carID);
    }
}
