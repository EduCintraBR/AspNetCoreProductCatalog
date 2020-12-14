using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.Repositories;
using ProductCatalog.ViewModels;
using System.Collections.Generic;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller 
    {
        public readonly CategoryRepository _repo;

        public CategoryController(CategoryRepository repository)
        {
            _repo = repository;
        }

        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _repo.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return _repo.Get(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _repo.GetProducts(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public ResultViewModel Post([FromBody]Category category)
        {
            category.Validate();
            if(category.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Save Category was failed",
                    Data = category.Notifications
                };

            _repo.Save(category);

            return new ResultViewModel
            {
                Success = true,
                Message = "Category was successfully saved",
                Data = category
            };
        }

        [Route("v1/categories")]
        [HttpPut]
        public ResultViewModel Put([FromBody]Category category)
        {
            category.Validate();
            if (category.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Update Category was failed",
                    Data = category.Notifications
                };

            _repo.Update(category);

            return new ResultViewModel
            {
                Success = true,
                Message = "Category was successfully updated",
                Data = category
            };
        }

        [Route("v1/categories")]
        [HttpDelete]
        public ResultViewModel Remove([FromBody]Category category)
        {
            _repo.Remove(category);

            return new ResultViewModel
            {
                Success = true,
                Message = "Category was successfully deleted",
                Data = category
            };
        }
    }
}
