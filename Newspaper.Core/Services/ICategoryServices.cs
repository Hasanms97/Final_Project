﻿using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Services
{
    public interface ICategoryServices
    {
        List<Category> GetAllCategory();
        Category GetCategoryById(int id);
        bool CreateNewCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}
