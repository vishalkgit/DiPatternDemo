﻿using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public interface ICategoryRepository
    {

        IEnumerable<Category> GetCategories();

        Category GetCategoryById(int id);
        int AddCategory(Category cat);
        int UpdateCategory(Category cat);
        int DeleteCategory(int id);

    }
}
