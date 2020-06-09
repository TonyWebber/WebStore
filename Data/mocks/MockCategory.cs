using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { Name = "Electric cars", Description = "Modern ecological vehicle" },
                    new Category { Name = "Cars", Description = "Vehicles with internal combustion engine" }
                };
            }
        }
    }
}
