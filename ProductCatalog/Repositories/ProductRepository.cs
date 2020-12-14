using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories.Interfaces;
using ProductCatalog.ViewModels.ProductViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDataContext _context;

        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }

        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _context.Products
                    .Include(x => x.Category)
                    .Select(x => new ListProductViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Price = x.Price,
                        Category = x.Category.Title,
                        CategoryId = x.Category.Id

                    }).AsNoTracking().ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
