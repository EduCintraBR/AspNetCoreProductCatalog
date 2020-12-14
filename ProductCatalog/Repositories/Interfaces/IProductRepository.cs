using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProductViewModels;
using System.Collections.Generic;

namespace ProductCatalog.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product Find(int id);
        IEnumerable<ListProductViewModel> Get();
        Product Get(int id);
        void Remove(Product product);
        void Save(Product product);
        void Update(Product product);
    }
}
