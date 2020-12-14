using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.Repositories;
using ProductCatalog.Repositories.Interfaces;
using ProductCatalog.ViewModels;
using System.Collections.Generic;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller 
    {
        public readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repository)
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
