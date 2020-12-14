using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories;
using ProductCatalog.ViewModels;
using ProductCatalog.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repo;

        public ProductController(ProductRepository repository)
        {
            _repo = repository;
        }

        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get()
        {
            return _repo.Get();
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return _repo.Get(id);
        }

        [Route("v1/products")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível inserir o produto",
                    Data = model.Notifications
                };

            var prod = new Product();
            prod.Title = model.Title;
            prod.CategoryId = model.CategoryId;
            prod.CreateDate = DateTime.Now;
            prod.LastUpdateDate = DateTime.Now;
            prod.Description = model.Description;
            prod.Image = model.Image;
            prod.Price = model.Price;
            prod.Quantity = model.Quantity;

            _repo.Save(prod);

            return new ResultViewModel
            {
                Success = true,
                Message = "Product was successfully saved",
                Data = prod
            };
        }

        [Route("v1/products")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorProductViewModel model)
        {
            var product = _repo.Find(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.LastUpdateDate = DateTime.Now;
            product.Description = model.Description;
            product.Image = model.Image;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repo.Save(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Product was successfully updated",
                Data = product
            };
        }

        [Route("v1/products")]
        [HttpDelete]
        public ResultViewModel Remove([FromBody] DeleteProductViewModel model)
        {
            var product = _repo.Find(model.Id);
            _repo.Remove(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Product deleted",
                Data = new DeleteProductViewModel
                {
                    Id = model.Id,
                    Title = model.Title
                }
            };
        }
    }
}
