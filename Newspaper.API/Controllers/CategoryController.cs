using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }


        [HttpGet("GetAllCategory")]
        public List<Category> GetAllCategory()
        {
            return _categoryServices.GetAllCategory();
        }

        [HttpGet("GetCategoryById/{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoryServices.GetCategoryById(id);
        }
        [HttpPost("CreateNewCategory")]
        public bool CreateNewCategory(Category category)
        {
            return _categoryServices.CreateNewCategory(category);
        }

        [HttpPut("UpdateCategory")]
        public bool UpdateCategory(Category category)
        {
            return _categoryServices.UpdateCategory(category);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public bool DeleteCategory(int id)
        {
            return _categoryServices.DeleteCategory(id);
        }

        [HttpPost("UploadImageCategory")]
        public Category UploadImageCategory()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/ImageCategory/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Category cate = new Category();
            cate.Imagepath = fileName;
            return cate;
        }

    }
}
