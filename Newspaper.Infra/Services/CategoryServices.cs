using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class CategoryServices : ICategoryServices
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAllCategory() { return _categoryRepository.GetAllCategory(); }
        public Category GetCategoryById(int id) { return _categoryRepository.GetCategoryById(id); }
        public bool CreateNewCategory(Category category) { return _categoryRepository.CreateNewCategory(category); }
        public bool UpdateCategory(Category category) { return _categoryRepository.UpdateCategory(category);}
        public bool DeleteCategory(int id) { return _categoryRepository.DeleteCategory(id); }
    }
}
