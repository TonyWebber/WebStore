using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Interfaces;
using WebStore.Data.Models;

namespace WebStore.Data.Repos

{
    public class CategoryRepos : ICarsCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepos(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
