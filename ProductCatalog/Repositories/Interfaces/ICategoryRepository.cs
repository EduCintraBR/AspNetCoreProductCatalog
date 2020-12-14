using ProductCatalog.Data;
using ProductCatalog.Models;
using System.Collections.Generic;

namespace ProductCatalog.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        IEnumerable<Product> GetProducts(int id);
        void Remove(Category category);
        void Save(Category category);
        void Update(Category category);
    }
}
